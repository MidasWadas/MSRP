import React from "react";
import "./minput.scss";
import { buildClassNames } from "@utils/classNameUtils";

export interface MInputProps {
	id?: string;
	name?: string;
	label: string;
	type?: "text" | "number" | "email" | "password" | "url";
	placeholder?: string;
	value: string | number;
	onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
	required?: boolean;
	disabled?: boolean;
	min?: number;
	max?: number;
	error?: string;
	helperText?: string;
	className?: string;
	fullWidth?: boolean;
}

const MInput: React.FC<MInputProps> = ({
	id,
	name,
	label,
	type = "text",
	placeholder,
	value,
	onChange,
	required = false,
	disabled = false,
	min,
	max,
	error,
	helperText,
	className = "",
	fullWidth = true,
}) => {
	const inputClasses = buildClassNames([
		"m-input",
		error && "m-input--error",
		disabled && "m-input--disabled",
		fullWidth && "m-input--full-width",
		className,
	]);

	return (
		<div className={inputClasses}>
			<label className="m-input__label">
				{label}
				{required && <span className="m-input__required">*</span>}
			</label>
			<input
				id={id}
				name={name}
				type={type}
				value={value}
				onChange={onChange}
				placeholder={placeholder}
				required={required}
				disabled={disabled}
				min={min}
				max={max}
				className="m-input__field"
			/>
			{(error || helperText) && (
				<div
					className={`m-input__message ${
						error ? "m-input__message--error" : ""
					}`}
				>
					{error || helperText}
				</div>
			)}
		</div>
	);
};

export default MInput;
