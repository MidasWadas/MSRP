import React, { JSX } from "react";
import MText, { MTextProps } from "@components/atoms/MText/MText";
import MButton, { MButtonProps } from "@components/atoms/MButton/MButton";
import "./mtag.scss";

export type TagVariant =
	| "primary"
	| "secondary"
	| "accent"
	| "success"
	| "warning"
	| "error"
	| "info"
	| "neutral"
	| "cuisine"
	| "meal"
	| "dietary";
export type TagSize = "small" | "medium" | "large";
export type TagShape = "rounded" | "pill" | "square";
export type TagAppearance = "filled" | "outlined" | "subtle" | "minimal";

interface MTagProps {
	label: string;
	variant?: TagVariant;
	size?: TagSize;
	shape?: TagShape;
	appearance?: TagAppearance;
	className?: string;
	onRemove?: () => void;
	removable?: boolean;
	disabled?: boolean;
	as?: keyof JSX.IntrinsicElements;
	labelProps?: Partial<MTextProps>;
	removeButtonProps?: Partial<MButtonProps>;
}

const MTag: React.FC<MTagProps> = ({
	label,
	variant = "primary",
	size = "medium",
	shape = "rounded",
	appearance = "filled",
	className = "",
	onRemove,
	removable = false,
	disabled = false,
	as = "span",
	labelProps = {},
	removeButtonProps = {},
}) => {
	const Tag = as;
	const tagClasses = [
		"m-tag",
		`m-tag--${variant}`,
		`m-tag--${size}`,
		`m-tag--shape-${shape}`,
		`m-tag--appearance-${appearance}`,
		disabled ? "m-tag--disabled" : "",
		removable ? "m-tag--removable" : "",
		className,
	]
		.filter(Boolean)
		.join(" ");

	const handleRemove = (e: React.MouseEvent) => {
		e.stopPropagation();
		if (!disabled && onRemove) {
			onRemove();
		}
	};

	return (
		<Tag className={tagClasses}>
			<MText
				text={label}
				size={labelProps.size || "sm"}
				color={labelProps.color || "inherit"}
				weight={labelProps.weight || "normal"}
				className={["m-tag__label", labelProps.className]
					.filter(Boolean)
					.join(" ")}
				{...labelProps}
			/>
			{removable && (
				<MButton
					variant={removeButtonProps.variant || "text"}
					size={removeButtonProps.size || "small"}
					icon={
						removeButtonProps.icon || (
							<svg
								xmlns="http://www.w3.org/2000/svg"
								width="16"
								height="16"
								viewBox="0 0 24 24"
								fill="none"
								stroke="currentColor"
								strokeWidth="2"
								strokeLinecap="round"
								strokeLinejoin="round"
							>
								<line x1="18" y1="6" x2="6" y2="18"></line>
								<line x1="6" y1="6" x2="18" y2="18"></line>
							</svg>
						)
					}
					showAsIcon
					className={["m-tag__remove", removeButtonProps.className]
						.filter(Boolean)
						.join(" ")}
					onClick={handleRemove}
					aria-label={`Remove ${label}`}
					disabled={disabled}
					{...removeButtonProps}
				/>
			)}
		</Tag>
	);
};

export default MTag;
