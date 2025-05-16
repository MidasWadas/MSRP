import React from "react";
import "./mcheckbox.scss";
import MText, { MTextProps } from "@components/atoms/MText/MText";

interface MCheckboxProps {
	checked: boolean;
	onChange: (checked: boolean) => void;
	label?: string;
	className?: string;
	disabled?: boolean;
	labelProps?: Partial<MTextProps>;
}
const MCheckbox: React.FC<MCheckboxProps> = ({
	checked,
	onChange,
	label,
	className = "",
	disabled = false,
	labelProps = {},
}) => {
	const containerClasses = [
		"m-checkbox",
		disabled ? "m-checkbox--disabled" : "",
		className,
	]
		.filter(Boolean)
		.join(" ");

	return (
		<div className={containerClasses}>
			<label className="m-checkbox__container">
				<input
					type="checkbox"
					checked={checked}
					disabled={disabled}
					onChange={(e) => onChange(e.target.checked)}
					className="m-checkbox__input"
				/>
				<span className="m-checkbox__checkmark"></span>
				{label && (
					<MText
						text={label}
						as={labelProps.as || "span"}
						size={labelProps.size || "md"}
						className={["m-checkbox__label", labelProps.className]
							.filter(Boolean)
							.join(" ")}
						{...labelProps}
					/>
				)}
			</label>
		</div>
	);
};

export default MCheckbox;
