import React from "react";
import "./micontext.scss";
import { buildClassNames } from "utils/classNameUtils";
import MText, { type MTextProps } from "components/atoms/MText/MText";

type IconPlacement = "left" | "right" | "top" | "bottom";

interface MIconTextProps extends MTextProps {
	icon: React.ReactNode;
	placement?: IconPlacement;
}
const MIconText: React.FC<MIconTextProps> = ({
	icon,
	text,
	placement = "left",
	className = "",
	...props
}) => {
	const containerClasses = buildClassNames([
		"m-icon-text",
		`m-icon-text--position-${placement}`,
		className,
	]);

	return (
		<div className={containerClasses}>
			<span className="m-icon-text__icon">{icon}</span>
			<MText
				className="m-icon-text__text"
				text={text}
				preserveNewlines={true}
				{...props}
			/>
		</div>
	);
};

export default MIconText;
