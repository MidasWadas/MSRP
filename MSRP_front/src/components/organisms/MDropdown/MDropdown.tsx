import React, { useState, useRef, useEffect, useMemo, useId } from "react";
import MText, { MTextProps } from "@components/atoms/MText/MText";
import MTag from "@components/molecules/MTag/MTag";
import "./mdropdown.scss";

// Base interface for dropdown option
export interface DropdownOption {
	value: number;
	label: string;
	icon?: React.ReactNode;
	badge?: React.ReactNode | string;
	description?: string;
	disabled?: boolean;
	group?: string;
}

// Context for dropdown state
interface DropdownContextType {
	isOpen: boolean;
	setIsOpen: React.Dispatch<React.SetStateAction<boolean>>;
	disabled: boolean;
	size: "small" | "medium" | "large";
	variant: "default" | "outlined" | "filled";
}

const DropdownContext = React.createContext<DropdownContextType>({
	isOpen: false,
	setIsOpen: () => {},
	disabled: false,
	size: "medium",
	variant: "default",
});

// Hook to use dropdown context
export const useDropdown = () => React.useContext(DropdownContext);

// Modified interface to support both single and multi-select
export interface MDropdownProps {
	className?: string;
	disabled?: boolean;
	size?: "small" | "medium" | "large";
	variant?: "default" | "outlined" | "filled";
	radius?: "none" | "small" | "medium" | "large";
	error?: string | boolean;
	fullWidth?: boolean;
	children?: React.ReactNode;
	label?: string;
	options?: DropdownOption[];
	selected?: number | number[];
	onChange?: (selected: number | number[]) => void;
	placeholder?: string;
	searchable?: boolean;
	multiSelect?: boolean;
	maxHeight?: number;
}

// Dropdown Label (Atom)
export interface MDropdownLabelProps extends Omit<MTextProps, "text"> {
	children: string;
}

// Dropdown Trigger (Atom)
export interface MDropdownTriggerProps {
	children?: React.ReactNode;
	placeholder?: string;
	className?: string;
}

// Dropdown Menu (Atom)
export interface MDropdownMenuProps {
	children: React.ReactNode;
	maxHeight?: number;
	className?: string;
}

// Dropdown Search (Atom)
export interface MDropdownSearchProps {
	value: string;
	onChange: (value: string) => void;
	placeholder?: string;
	className?: string;
}

// Dropdown Options Container (Atom)
export interface MDropdownOptionsProps {
	children: React.ReactNode;
	className?: string;
}

// Dropdown Option (Atom)
export interface MDropdownOptionProps {
	value: number;
	label: string;
	icon?: React.ReactNode;
	badge?: React.ReactNode | string;
	description?: string;
	disabled?: boolean;
	isSelected?: boolean;
	onClick: (
		value: number,
		disabled: boolean,
		event: React.MouseEvent
	) => void;
	className?: string;
}

// Dropdown Group (Atom)
export interface MDropdownGroupProps {
	label: string;
	children: React.ReactNode;
	className?: string;
}

// Dropdown Empty (Atom)
export interface MDropdownEmptyProps {
	message?: string;
	searchTerm?: string;
	className?: string;
}

// Dropdown Tags Container (Atom)
export interface MDropdownTagsProps {
	children: React.ReactNode;
	className?: string;
}

// Dropdown Error (Atom)
export interface MDropdownErrorProps {
	message: string;
	className?: string;
}

// Root dropdown component (Atom)
const MDropdown = React.forwardRef<HTMLDivElement, MDropdownProps>(
	(
		{
			className = "",
			disabled = false,
			size = "medium",
			variant = "default",
			radius = "medium",
			error = false,
			fullWidth = false,
			children,
			label,
			options = [],
			selected = [],
			onChange,
			placeholder = "Select...",
			searchable = false,
			multiSelect = true,
			maxHeight = 300,
		},
		ref
	) => {
		const [isOpen, setIsOpen] = useState(false);
		const [searchTerm, setSearchTerm] = useState("");

		const dropdownRef = useRef<HTMLDivElement>(null);

		// Close dropdown when clicking outside
		useEffect(() => {
			const handleClickOutside = (event: MouseEvent) => {
				if (
					dropdownRef.current &&
					!dropdownRef.current.contains(event.target as Node) &&
					isOpen
				) {
					setIsOpen(false);
				}
			};

			document.addEventListener("mousedown", handleClickOutside);
			return () =>
				document.removeEventListener("mousedown", handleClickOutside);
		}, [isOpen]);

		// Handle escape key to close dropdown
		useEffect(() => {
			const handleKeyDown = (event: KeyboardEvent) => {
				if (event.key === "Escape" && isOpen) {
					setIsOpen(false);
				}
			};

			document.addEventListener("keydown", handleKeyDown);
			return () => document.removeEventListener("keydown", handleKeyDown);
		}, [isOpen]);

		const dropdownClasses = [
			"m-dropdown",
			isOpen && "m-dropdown--open",
			disabled && "m-dropdown--disabled",
			error && "m-dropdown--error",
			fullWidth && "m-dropdown--full-width",
			size !== "medium" && `m-dropdown--${size}`,
			variant !== "default" && `m-dropdown--${variant}`,
			radius !== "medium" && `m-dropdown--radius-${radius}`,
			className,
		]
			.filter(Boolean)
			.join(" ");

		// Context provider for dropdown state
		const dropdownContext = {
			isOpen,
			setIsOpen,
			disabled,
			size,
			variant,
		};

		const filteredOptions = useMemo(() => {
			if (!searchTerm) return options;

			return options.filter((option) =>
				option.label.toLowerCase().includes(searchTerm.toLowerCase())
			);
		}, [options, searchTerm]);

		const groupedOptions = useMemo(() => {
			const groups: { [key: string]: DropdownOption[] } = {};
			const ungrouped: DropdownOption[] = [];

			filteredOptions.forEach((option) => {
				if (option.group) {
					if (!groups[option.group]) {
						groups[option.group] = [];
					}
					groups[option.group].push(option);
				} else {
					ungrouped.push(option);
				}
			});

			return { groups, ungrouped };
		}, [filteredOptions]);

		const handleOptionClick = (
			value: number,
			disabled: boolean,
			event: React.MouseEvent
		) => {
			event.stopPropagation();

			if (disabled) return;

			let updatedSelection: number[];

			if (multiSelect) {
				const isSelected =
					Array.isArray(selected) && selected.includes(value);

				if (isSelected) {
					updatedSelection = (
						Array.isArray(selected) ? selected : []
					).filter((item) => item !== value);
				} else {
					updatedSelection = [
						...(Array.isArray(selected) ? selected : []),
						value,
					];
				}
			} else {
				updatedSelection = [value];
				setIsOpen(false);
			}

			onChange?.(multiSelect ? updatedSelection : updatedSelection[0]);

			if (!multiSelect) {
				setSearchTerm("");
			}
		};

		const getSelectedText = () => {
			if (!selected || (Array.isArray(selected) && selected.length === 0))
				return placeholder;

			if (!Array.isArray(selected)) {
				const selectedOption = options.find(
					(opt) => opt.value === selected
				);
				return selectedOption ? selectedOption.label : placeholder;
			}

			if (selected.length === 1) {
				const selectedOption = options.find(
					(opt) => opt.value === selected[0]
				);
				return selectedOption ? selectedOption.label : placeholder;
			}

			return `${selected.length} ${
				selected.length === 1 ? "item" : "items"
			} selected`;
		};

		return (
			<DropdownContext.Provider value={dropdownContext}>
				<div
					className={dropdownClasses}
					ref={(node) => {
						// Merge refs
						if (typeof ref === "function") {
							ref(node);
						} else if (ref) {
							ref.current = node;
						}
						dropdownRef.current = node;
					}}
					data-testid="m-dropdown"
				>
					{label && <MDropdownLabel>{label}</MDropdownLabel>}

					<MDropdownTrigger placeholder={placeholder}>
						{getSelectedText()}
					</MDropdownTrigger>

					<MDropdownMenu maxHeight={maxHeight}>
						{searchable && (
							<MDropdownSearch
								value={searchTerm}
								onChange={setSearchTerm}
							/>
						)}

						<MDropdownOptions>
							{/* Ungrouped options */}
							{groupedOptions.ungrouped.map((option) => (
								<MDropdownOption
									key={option.value}
									value={option.value}
									label={option.label}
									icon={option.icon}
									badge={option.badge}
									description={option.description}
									disabled={option.disabled}
									isSelected={
										Array.isArray(selected)
											? selected.includes(option.value)
											: selected === option.value
									}
									onClick={handleOptionClick}
								/>
							))}

							{/* Grouped options */}
							{Object.entries(groupedOptions.groups).map(
								([groupName, groupOptions]) => (
									<MDropdownGroup
										key={groupName}
										label={groupName}
									>
										{groupOptions.map((option) => (
											<MDropdownOption
												key={option.value}
												value={option.value}
												label={option.label}
												icon={option.icon}
												badge={option.badge}
												description={option.description}
												disabled={option.disabled}
												isSelected={
													Array.isArray(selected)
														? selected.includes(
																option.value
														  )
														: selected ===
														  option.value
												}
												onClick={handleOptionClick}
											/>
										))}
									</MDropdownGroup>
								)
							)}

							{/* Empty state */}
							{filteredOptions.length === 0 && (
								<MDropdownEmpty searchTerm={searchTerm} />
							)}
						</MDropdownOptions>
					</MDropdownMenu>
				</div>
			</DropdownContext.Provider>
		);
	}
);

const MDropdownLabel = ({
	children,
	as = "label",
	size = "sm",
	className = "",
	...restProps
}: MDropdownLabelProps) => {
	return (
		<MText
			text={children}
			as={as}
			size={size}
			className={["m-dropdown__label", className]
				.filter(Boolean)
				.join(" ")}
			{...restProps}
		/>
	);
};

const MDropdownTrigger = ({
	children,
	placeholder = "Select...",
	className = "",
}: MDropdownTriggerProps) => {
	const { isOpen, setIsOpen, disabled } = useDropdown();
	const id = useId();

	const toggleDropdown = () => {
		if (!disabled) {
			setIsOpen(!isOpen);
		}
	};

	return (
		<div
			className={["m-dropdown__selector", className]
				.filter(Boolean)
				.join(" ")}
			onClick={toggleDropdown}
			role="combobox"
			aria-expanded={isOpen}
			aria-haspopup="listbox"
			aria-disabled={disabled}
			tabIndex={disabled ? -1 : 0}
			id={`${id}-selector`}
			aria-controls={isOpen ? `${id}-listbox` : undefined}
		>
			<span className="m-dropdown__selected">
				{children || placeholder}
			</span>

			<span className="m-dropdown__arrow">
				<svg
					xmlns="http://www.w3.org/2000/svg"
					width="12"
					height="12"
					viewBox="0 0 24 24"
					fill="none"
					stroke="currentColor"
					strokeWidth="2"
					strokeLinecap="round"
					strokeLinejoin="round"
				>
					<polyline points="6 9 12 15 18 9"></polyline>
				</svg>
			</span>
		</div>
	);
};

const MDropdownMenu = ({
	children,
	maxHeight = 300,
	className = "",
}: MDropdownMenuProps) => {
	const { isOpen } = useDropdown();
	const id = useId();

	if (!isOpen) {
		return null;
	}

	return (
		<div
			className={["m-dropdown__menu", className]
				.filter(Boolean)
				.join(" ")}
			role="listbox"
			id={`${id}-listbox`}
			style={{ maxHeight: `${maxHeight}px` }}
		>
			{children}
		</div>
	);
};

const MDropdownSearch = ({
	value,
	onChange,
	placeholder = "Search...",
	className = "",
}: MDropdownSearchProps) => {
	const inputRef = useRef<HTMLInputElement>(null);
	const { isOpen } = useDropdown();

	useEffect(() => {
		if (isOpen && inputRef.current) {
			inputRef.current.focus();
		}
	}, [isOpen]);

	return (
		<div
			className={["m-dropdown__search", className]
				.filter(Boolean)
				.join(" ")}
		>
			<input
				type="text"
				className="m-dropdown__search-input"
				placeholder={placeholder}
				value={value}
				onChange={(e) => onChange(e.target.value)}
				onClick={(e) => e.stopPropagation()}
				ref={inputRef}
				aria-label="Search dropdown options"
			/>
		</div>
	);
};

const MDropdownOptions = ({
	children,
	className = "",
}: MDropdownOptionsProps) => {
	return (
		<div
			className={["m-dropdown__options", className]
				.filter(Boolean)
				.join(" ")}
		>
			{children}
		</div>
	);
};

const MDropdownOption = ({
	value,
	label,
	icon,
	badge,
	description,
	disabled = false,
	isSelected = false,
	onClick,
	className = "",
}: MDropdownOptionProps) => {
	const optionClasses = [
		"m-dropdown__option",
		isSelected && "m-dropdown__option--selected",
		disabled && "m-dropdown__option--disabled",
		className,
	]
		.filter(Boolean)
		.join(" ");

	return (
		<div
			className={optionClasses}
			onClick={(e) => onClick(value, disabled, e)}
			role="option"
			aria-selected={isSelected}
			data-value={value}
		>
			{icon && <span className="m-dropdown__option-icon">{icon}</span>}

			<div className="m-dropdown__option-content">
				<span className="m-dropdown__option-label">{label}</span>

				{description && (
					<span className="m-dropdown__option-description">
						{description}
					</span>
				)}
			</div>

			{badge && <span className="m-dropdown__option-badge">{badge}</span>}
		</div>
	);
};

const MDropdownGroup = ({
	label,
	children,
	className = "",
}: MDropdownGroupProps) => {
	return (
		<div
			className={["m-dropdown__group", className]
				.filter(Boolean)
				.join(" ")}
		>
			<div className="m-dropdown__group-header">{label}</div>
			{children}
		</div>
	);
};

const MDropdownEmpty = ({
	message = "No options available",
	searchTerm = "",
	className = "",
}: MDropdownEmptyProps) => {
	return (
		<div
			className={["m-dropdown__empty", className]
				.filter(Boolean)
				.join(" ")}
		>
			{searchTerm ? `No matches for "${searchTerm}"` : message}
		</div>
	);
};

const MDropdownTags = ({ children, className = "" }: MDropdownTagsProps) => {
	return (
		<div
			className={["m-dropdown__tags", className]
				.filter(Boolean)
				.join(" ")}
		>
			{children}
		</div>
	);
};

const MDropdownError = ({ message, className = "" }: MDropdownErrorProps) => {
	return (
		<div
			className={["m-dropdown__error-message", className]
				.filter(Boolean)
				.join(" ")}
		>
			<MText text={message} size="sm" color="error" />
		</div>
	);
};

MDropdown.displayName = "MDropdown";

export default MDropdown;
export {
	MDropdownLabel,
	MDropdownTrigger,
	MDropdownMenu,
	MDropdownSearch,
	MDropdownOptions,
	MDropdownOption,
	MDropdownGroup,
	MDropdownEmpty,
	MDropdownTags,
	MDropdownError,
};
