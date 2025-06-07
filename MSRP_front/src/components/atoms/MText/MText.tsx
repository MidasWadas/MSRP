import React, { type JSX } from "react";
import "./mtext.scss";

export type TextColor =
	| "default"
	| "primary"
	| "secondary"
	| "accent"
	| "success"
	| "error"
	| "warning"
	| "info"
	| "light"
	| "muted"
	| "inherit";
export type TextAlign = "left" | "center" | "right" | "justify";
export type TextSize = "xs" | "sm" | "md" | "lg" | "xl" | "xxl";
export type TextWeight = "normal" | "medium" | "semibold" | "bold";

export interface MTextProps {
	text: string;
	color?: TextColor;
	align?: TextAlign;
	size?: TextSize;
	weight?: TextWeight;
	className?: string;
	as?: keyof JSX.IntrinsicElements;
	preserveNewlines?: boolean;
}
const MText: React.FC<MTextProps> = ({
	text,
	color = "default",
	align = "left",
	size = "md",
	weight = "normal",
	className = "",
	as = "span",
	preserveNewlines = false,
}) => {
	const classes = [
		"m-text",
		`m-text--color-${color}`,
		`m-text--align-${align}`,
		`m-text--size-${size}`,
		`m-text--weight-${weight}`,
		className,
	]
		.filter(Boolean)
		.join(" ");

	const Tag = as;

	if (preserveNewlines) {
		return (
			<Tag className={classes}>
				{text.split("\n").map((line, i) => (
					<React.Fragment key={i}>
						{i > 0 && <br />}
						{line}
					</React.Fragment>
				))}
			</Tag>
		);
	}

	return <Tag className={classes}>{text}</Tag>;
};

export default MText;
