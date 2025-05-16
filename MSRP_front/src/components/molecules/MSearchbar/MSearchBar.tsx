import React from "react";
import MInput from "@components/atoms/MInput/MInput";
import "./msearchbar.scss";

interface MSearchBarProps {
	value: string;
	onChange: (value: string) => void;
	searchLabel?: string;
	className?: string;
	disabled?: boolean;
	compact?: boolean; // New prop for compact mode
}

/**
 * MSearchBar - A search input component that uses MInput with a search icon
 */
const MSearchBar: React.FC<MSearchBarProps> = ({
	value,
	onChange,
	searchLabel = "Search...",
	className = "",
	disabled = false,
	compact = false, // Default to non-compact
}) => {
	const wrapperClass = `m-searchbar-wrapper ${
		compact ? "m-searchbar-wrapper--compact" : ""
	} ${className}`.trim();

	return (
		<div className={wrapperClass}>
			<MInput
				value={value}
				onChange={(e) => onChange(e.target.value)}
				label={compact ? "" : searchLabel}
				placeholder={searchLabel}
				disabled={disabled}
				className={`m-searchbar-input ${
					compact ? "m-searchbar-input--compact" : ""
				}`}
			/>
			<div className="m-searchbar__icon">
				<svg
					viewBox="0 0 24 24"
					fill="none"
					xmlns="http://www.w3.org/2000/svg"
				>
					<path d="M15.5 14H14.71L14.43 13.73C15.41 12.59 16 11.11 16 9.5C16 5.91 13.09 3 9.5 3C5.91 3 3 5.91 3 9.5C3 13.09 5.91 16 9.5 16C11.11 16 12.59 15.41 13.73 14.43L14 14.71V15.5L19 20.49L20.49 19L15.5 14ZM9.5 14C7.01 14 5 11.99 5 9.5C5 7.01 7.01 5 9.5 5C11.99 5 14 7.01 14 9.5C14 11.99 11.99 14 9.5 14Z" />
				</svg>
			</div>
		</div>
	);
};

export default MSearchBar;
