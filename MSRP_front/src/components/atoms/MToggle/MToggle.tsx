import React from "react";
import "./mtoggle.scss";

export interface MToggleProps {
	checked: boolean;
	onChange: (checked: boolean) => void;
	className?: string;
	disabled?: boolean;
}

const MToggle: React.FC<MToggleProps> = ({
	checked,
	onChange,
	className = "",
	disabled = false,
}) => {
	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		if (!disabled) {
			onChange(e.target.checked);
		}
	};

	const containerClasses = [
		"m-toggle",
		checked ? "m-toggle--checked" : "",
		disabled ? "m-toggle--disabled" : "",
		className,
	]
		.filter(Boolean)
		.join(" ");

	return (
		<div className={containerClasses}>
			<input
				type="checkbox"
				className="m-toggle__input"
				checked={checked}
				onChange={handleChange}
				disabled={disabled}
			/>
			<div className="m-toggle__control">
				<div className="m-toggle__track" />
				<div className="m-toggle__thumb" />
			</div>
		</div>
	);
};

export default MToggle;
