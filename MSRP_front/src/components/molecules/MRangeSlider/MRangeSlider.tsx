import React, { useState, useRef, useEffect } from "react";
import "./mrange-slider.scss";
import MText, { type MTextProps } from "components/atoms/MText/MText";

interface MRangeSliderProps {
	min: number;
	max: number;
	value: number;
	onChange: (value: number) => void;
	className?: string;
	disabled?: boolean;
	valueLabelProps?: Partial<MTextProps>;
}

const MRangeSlider: React.FC<MRangeSliderProps> = ({
	min,
	max,
	value,
	onChange,
	className = "",
	disabled = false,
	valueLabelProps = {},
}) => {
	const sliderRef = useRef<HTMLDivElement>(null);
	const [isDragging, setIsDragging] = useState(false);
	const [localValue, setLocalValue] = useState<number>(value);

	useEffect(() => {
		if (!isDragging) {
			setLocalValue(value);
		}
	}, [value, isDragging]);

	const clampValue = (val: number): number =>
		Math.min(Math.max(val, min), max);
	const getPercent = (val: number): number =>
		((val - min) / (max - min)) * 100;

	const handleTrackClick = (event: React.MouseEvent) => {
		if (disabled) return;
		const slider = sliderRef.current;
		if (!slider) return;
		const rect = slider.getBoundingClientRect();
		const position = event.clientX - rect.left;
		const percent = position / rect.width;
		const newValue = clampValue(Math.round(min + percent * (max - min)));
		setLocalValue(newValue);
		onChange(newValue);
	};

	const handleThumbMouseDown = (event: React.MouseEvent) => {
		if (disabled) return;
		setIsDragging(true);
		document.addEventListener("mousemove", handleMouseMove);
		document.addEventListener("mouseup", handleMouseUp);
		event.preventDefault();
	};

	const handleMouseMove = (event: MouseEvent) => {
		if (!isDragging) return;
		const slider = sliderRef.current;
		if (!slider) return;
		const rect = slider.getBoundingClientRect();
		const position = event.clientX - rect.left;
		const percent = position / rect.width;
		const newValue = clampValue(Math.round(min + percent * (max - min)));
		setLocalValue(newValue);
		onChange(newValue);
	};

	const handleMouseUp = () => {
		setIsDragging(false);
		document.removeEventListener("mousemove", handleMouseMove);
		document.removeEventListener("mouseup", handleMouseUp);
	};

	const sliderClasses = [
		"m-range-slider",
		disabled ? "m-range-slider--disabled" : "",
		className,
	]
		.filter(Boolean)
		.join(" ");

	return (
		<div className={sliderClasses}>
			<div className="m-range-slider__container">
				<div
					className="m-range-slider__track-container"
					ref={sliderRef}
					onClick={handleTrackClick}
				>
					<div className="m-range-slider__track" />
					<div
						className="m-range-slider__track-fill"
						style={{ left: 0, width: `${getPercent(localValue)}%` }}
					/>
					<div
						className="m-range-slider__thumb"
						style={{ left: `${getPercent(localValue)}%` }}
						onMouseDown={handleThumbMouseDown}
						tabIndex={disabled ? -1 : 0}
						role="slider"
						aria-valuenow={localValue}
						aria-valuemin={min}
						aria-valuemax={max}
						aria-disabled={disabled}
					>
						<MText
							text={String(localValue)}
							as={valueLabelProps.as || "div"}
							size={valueLabelProps.size || "sm"}
							className={[
								"m-range-slider__value-label",
								valueLabelProps.className,
							]
								.filter(Boolean)
								.join(" ")}
							{...valueLabelProps}
						/>
					</div>
				</div>
			</div>
		</div>
	);
};

export default MRangeSlider;
