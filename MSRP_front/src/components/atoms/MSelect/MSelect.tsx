import React from "react";
import "./mselect.scss";
import { type IdName } from "types/common";

export interface MSelectProps {
	id?: string;
	name?: string;
	label: string;
	options: IdName[];
	value: number;
	onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void;
	required?: boolean;
	disabled?: boolean;
	error?: string;
	helperText?: string;
	className?: string;
	fullWidth?: boolean;
}

const MSelect: React.FC<MSelectProps> = ({
	id,
	name,
	label,
	options,
	value,
	onChange,
	required = false,
	disabled = false,
	error,
	helperText,
	className = "",
	fullWidth = true,
}) => {
	const selectClasses = [
		"m-select",
		error && "m-select--error",
		disabled && "m-select--disabled",
		fullWidth && "m-select--full-width",
		className,
	]
		.filter(Boolean)
		.join(" ");

	return (
		<div className={selectClasses}>
			<label className="m-select__label">
				{label}
				{required && <span className="m-select__required">*</span>}
			</label>
			<div className="m-select__wrapper">
				<select
					id={id}
					name={name}
					value={value}
					onChange={onChange}
					required={required}
					disabled={disabled}
					className="m-select__field"
				>
					{options.map((option) => (
						<option key={option.id} value={option.id}>
							{option.name}
						</option>
					))}
				</select>
				<div className="m-select__arrow"></div>
			</div>
			{(error || helperText) && (
				<div
					className={`m-select__message ${
						error ? "m-select__message--error" : ""
					}`}
				>
					{error || helperText}
				</div>
			)}
		</div>
	);
};

export default MSelect;
