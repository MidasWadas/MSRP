import React from "react";
import "./mtextarea.scss";
import { buildClassNames } from "utils/classNameUtils";

export interface MTextareaProps {
	id?: string;
	name?: string;
	label: string;
	placeholder?: string;
	value: string;
	onChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
	required?: boolean;
	disabled?: boolean;
	rows?: number;
	error?: string;
	helperText?: string;
	className?: string;
	fullWidth?: boolean;
}

const MTextarea: React.FC<MTextareaProps> = ({
	id,
	name,
	label,
	placeholder,
	value,
	onChange,
	required = false,
	disabled = false,
	rows = 4,
	error,
	helperText,
	className = "",
	fullWidth = true,
}) => {
	const textareaClasses = buildClassNames([
		"m-textarea",
		error && "m-textarea--error",
		disabled && "m-textarea--disabled",
		fullWidth && "m-textarea--full-width",
		className,
	]);

	return (
		<div className={textareaClasses}>
			<label className="m-textarea__label">
				{label}
				{required && <span className="m-textarea__required">*</span>}
			</label>
			<textarea
				id={id}
				name={name}
				value={value}
				onChange={onChange}
				placeholder={placeholder}
				required={required}
				disabled={disabled}
				rows={rows}
				className="m-textarea__field"
			/>
			{(error || helperText) && (
				<div
					className={`m-textarea__message ${
						error ? "m-textarea__message--error" : ""
					}`}
				>
					{error || helperText}
				</div>
			)}
		</div>
	);
};

export default MTextarea;
