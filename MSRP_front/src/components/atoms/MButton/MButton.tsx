import React, { forwardRef } from "react";
import { buildClassNames } from "utils/classNameUtils";
import "./mbutton.scss";

export type ButtonVariant =
	| "primary"
	| "secondary"
	| "accent"
	| "outlined"
	| "text"
	| "error";
export type ButtonSize = "small" | "medium" | "large";

export interface MButtonProps
	extends React.ButtonHTMLAttributes<HTMLButtonElement> {
	children?: React.ReactNode;
	text?: string;
	icon?: React.ReactNode;
	showAsIcon?: boolean;
	variant?: ButtonVariant;
	size?: ButtonSize;
	rounded?: boolean;
	disabled?: boolean;
	className?: string;
	onClick?: (event: React.MouseEvent<HTMLButtonElement>) => void;
}

const MButton = forwardRef<HTMLButtonElement, MButtonProps>(
	(
		{
			children,
			text,
			icon,
			showAsIcon = false,
			variant = "primary",
			size = "medium",
			rounded = false,
			className = "",
			onClick,
			disabled = false,
			...rest
		},
		ref
	) => {
		const buttonClasses = buildClassNames([
			"m-button",
			`m-button--${variant}`,
			`m-button--${size}`,
			rounded && "m-button--rounded",
			className,
		]);

		const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
			if (disabled) return;
			onClick?.(event);
		};

		return (
			<button
				ref={ref}
				className={buttonClasses}
				disabled={disabled}
				onClick={handleClick}
				{...rest}
			>
				{icon && <span className="m-button__icon">{icon}</span>}
				{showAsIcon ? null : (
					<span className="m-button__text">{text || children}</span>
				)}
			</button>
		);
	}
);

MButton.displayName = "MButton";

export default MButton;
