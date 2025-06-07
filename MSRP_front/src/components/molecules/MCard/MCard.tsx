import React from "react";
import { buildClassNames } from "utils/classNameUtils";
import MText, { type MTextProps } from "components/atoms/MText/MText";
import MButton, { type MButtonProps } from "components/atoms/MButton/MButton";
import "./mcard.scss";

export interface MCardProps {
	children?: React.ReactNode;
	className?: string;
	elevation?: 0 | 1 | 2 | 3;
	variant?: "default" | "outlined";
	size?: "small" | "medium" | "large";
	radius?: "none" | "small" | "medium" | "large" | "full";
	clickable?: boolean;
	onClick?: React.MouseEventHandler<HTMLDivElement>;
	title?: string;
	subtitle?: string;
	titleProps?: Partial<MTextProps>;
	subtitleProps?: Partial<MTextProps>;
	actions?: React.ReactNode;
	actionButtonProps?: Partial<MButtonProps>;
	media?: string;
	mediaAlt?: string;
	mediaPosition?: "top" | "bottom";
	layout?: "vertical" | "horizontal";
	fullWidth?: boolean;
}

const MCard = React.forwardRef<HTMLDivElement, MCardProps>(
	(
		{
			children,
			className = "",
			elevation = 1,
			variant = "default",
			size = "medium",
			radius = "medium",
			clickable = false,
			onClick,
			title,
			subtitle,
			titleProps = {},
			subtitleProps = {},
			actions,
			actionButtonProps = {},
			media,
			mediaAlt = "",
			mediaPosition = "top",
			layout = "vertical",
			fullWidth = false,
		},
		ref
	) => {
		const cardClasses = buildClassNames([
			"m-card",
			`m-card--elevation-${elevation}`,
			variant !== "default" && `m-card--${variant}`,
			size !== "medium" && `m-card--${size}`,
			radius !== "medium" && `m-card--radius-${radius}`,
			layout === "horizontal" && "m-card--horizontal",
			clickable && "m-card--clickable",
			fullWidth && "m-card--full-width",
			className,
		]);

		return (
			<div
				ref={ref}
				className={cardClasses}
				onClick={clickable ? onClick : undefined}
				tabIndex={clickable && onClick ? 0 : undefined}
				role={clickable && onClick ? "button" : undefined}
			>
				{media && mediaPosition === "top" && (
					<div className="m-card__media">
						<img
							src={media}
							alt={mediaAlt}
							className="m-card__media-img"
						/>
					</div>
				)}

				{(title || subtitle) && (
					<div className="m-card__header">
						<div className="m-card__header-content">
							{title && (
								<MText
									text={title}
									as={titleProps.as || "h3"}
									size={titleProps.size || "lg"}
									weight={titleProps.weight || "bold"}
									className={[
										"m-card__title",
										titleProps.className,
									]
										.filter(Boolean)
										.join(" ")}
									{...titleProps}
								/>
							)}
							{subtitle && (
								<MText
									text={subtitle}
									as={subtitleProps.as || "div"}
									size={subtitleProps.size || "sm"}
									color={subtitleProps.color || "muted"}
									className={[
										"m-card__subtitle",
										subtitleProps.className,
									]
										.filter(Boolean)
										.join(" ")}
									{...subtitleProps}
								/>
							)}
						</div>
					</div>
				)}

				<div className="m-card__content">{children}</div>

				{media && mediaPosition === "bottom" && (
					<div className="m-card__media">
						<img
							src={media}
							alt={mediaAlt}
							className="m-card__media-img"
						/>
					</div>
				)}

				{actions && (
					<div className="m-card__footer-actions">{actions}</div>
				)}
			</div>
		);
	}
);

MCard.displayName = "MCard";

export default MCard;
