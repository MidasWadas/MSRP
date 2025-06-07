import React from "react";
import "./EmptyState.scss";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";

interface EmptyStateProps {
	message: string;
	icon?: string;
	action?: {
		label: string;
		onClick: () => void;
	};
}

const EmptyState: React.FC<EmptyStateProps> = ({
	message,
	icon = "🍳",
	action,
}) => {
	return (
		<div className="empty-state">
			<div className="empty-icon">{icon}</div>
			<MText
				text={message}
				as="div"
				size="md"
				color="muted"
				className="empty-message"
			/>
			{action && <MButton className="empty-action" {...action} />}
		</div>
	);
};

export default EmptyState;
