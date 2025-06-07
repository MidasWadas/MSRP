import React from "react";
import MText, { type MTextProps } from "components/atoms/MText/MText";
import MCheckbox from "components/molecules/MCheckbox/MCheckbox";
import MButton from "components/atoms/MButton/MButton";
import "./mfilter-group.scss";

export interface FilterOption {
	value: string;
	label: string;
	disabled?: boolean;
	count?: number;
	icon?: React.ReactNode;
}

interface MFilterGroupProps {
	title: string;
	options: FilterOption[];
	selected: string[];
	onChange: (selected: string[]) => void;
	className?: string;
	titleProps?: Partial<MTextProps>;
	optionLabelProps?: Partial<MTextProps>;
}

const MFilterGroup: React.FC<MFilterGroupProps> = ({
	title,
	options,
	selected,
	onChange,
	className = "",
	titleProps = {},
	optionLabelProps = {},
}) => {
	const handleOptionToggle = (optionValue: string) => {
		if (selected.includes(optionValue)) {
			onChange(selected.filter((value) => value !== optionValue));
		} else {
			onChange([...selected, optionValue]);
		}
	};

	const containerClasses = ["m-filter-group", className]
		.filter(Boolean)
		.join(" ");

	return (
		<div
			className={containerClasses}
			role="group"
			aria-labelledby={`${title}-title`}
		>
			<div className="m-filter-group__header">
				<MText
					text={title}
					as={titleProps.as || "h3"}
					size={titleProps.size || "lg"}
					weight={titleProps.weight || "bold"}
					className={["m-filter-group__title", titleProps.className]
						.filter(Boolean)
						.join(" ")}
					{...titleProps}
				/>
			</div>
			<div className={`m-filter-group__options`}>
				{options.map((option) => (
					<div
						className="m-filter-group__option-wrapper"
						key={option.value}
					>
						<MCheckbox
							label={option.label}
							checked={selected.includes(option.value)}
							onChange={() => handleOptionToggle(option.value)}
							disabled={option.disabled}
							labelProps={{
								...optionLabelProps,
								className: [
									"m-filter-group__option-text",
									optionLabelProps.className,
								]
									.filter(Boolean)
									.join(" "),
							}}
						/>
						{option.icon && (
							<span className="m-filter-group__option-icon">
								{option.icon}
							</span>
						)}
						{option.count !== undefined && (
							<span className="m-filter-group__option-count">
								({option.count})
							</span>
						)}
					</div>
				))}
			</div>
		</div>
	);
};

export default MFilterGroup;

export const FilterSelectAllButton: React.FC<{
	onClick: () => void;
	disabled?: boolean;
}> = ({ onClick, disabled }) => (
	<MButton
		text="Select All"
		className="m-filter-action-btn"
		onClick={onClick}
		disabled={disabled}
	/>
);

export const FilterClearButton: React.FC<{
	onClick: () => void;
	disabled?: boolean;
}> = ({ onClick, disabled }) => (
	<MButton
		text="Clear"
		className="m-filter-action-btn"
		onClick={onClick}
		disabled={disabled}
	/>
);
