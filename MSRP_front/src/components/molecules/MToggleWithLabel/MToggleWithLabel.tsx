import React from "react";
import MToggle, { MToggleProps } from "@components/atoms/MToggle/MToggle";
import MText, { MTextProps } from "@components/atoms/MText/MText";
import "./mtogglewithlabel.scss";

interface MToggleWithLabelProps extends MToggleProps {
	labelPosition?: "left" | "right";
}

const MToggleWithLabel: React.FC<MToggleWithLabelProps & MTextProps> = ({
	labelPosition = "right",
	...props
}) => {
	const { text, ...mTextProps } = props;
	return (
		<div className={`m-toggle-with-label ${props.className || ""}`.trim()}>
			{labelPosition === "left" && <MText text={text} {...mTextProps} />}
			<MToggle {...props} />
			{labelPosition === "right" && <MText text={text} {...mTextProps} />}
		</div>
	);
};

export default MToggleWithLabel;
