import React from "react";
import "./RandomizerPanel.scss";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";

interface RandomizerPanelProps {
	onRandomize: () => void;
	onReset: () => void;
	isRandomizing: boolean;
	hasFilters: boolean;
}

const RandomizerPanel: React.FC<RandomizerPanelProps> = ({
	onRandomize,
	onReset,
	isRandomizing,
	hasFilters,
}) => {
	return (
		<div className="randomizer-panel">
			<div className="randomizer-buttons">
				<MButton
					className="surprise-button"
					text={isRandomizing ? "Finding..." : "Surprise Me! 🎲"}
					onClick={onRandomize}
					disabled={isRandomizing}
					variant="accent"
					size="large"
				/>
				{hasFilters && (
					<div className="filter-info">
						<span className="filter-badge">Filters Active</span>
						<MButton
							className="reset-filters"
							text="Reset"
							onClick={onReset}
							variant="outlined"
							size="small"
						/>
					</div>
				)}
			</div>
			<div className="randomizer-tips">
				<MText text="Tips:" as="h3" size="md" weight="bold" />
				<ul>
					<li>Use filters to narrow down suggestions</li>
					<li>
						Looking for quick meals? Set max prep time to 15 minutes
					</li>
					<li>
						Enable "Use available ingredients" to only suggest
						recipes you can make right now
					</li>
				</ul>
			</div>
		</div>
	);
};

export default RandomizerPanel;
