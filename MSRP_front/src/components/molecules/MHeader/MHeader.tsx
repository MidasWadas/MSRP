import React from "react";
import "./mheader.scss";
import MText, { type MTextProps } from "components/atoms/MText/MText";

export type HeaderSize = "default" | "small" | "medium" | "large" | "xlarge";

interface MHeaderProps {
	title?: string;
	titleContent?: React.ReactNode;
	className?: string;
	size?: HeaderSize;
	titleProps?: Partial<MTextProps>;
}

const MHeader: React.FC<MHeaderProps> = ({
	title,
	titleContent,
	className = "",
	size = "default",
	titleProps = {},
}) => {
	const headerClasses = ["m-header", `m-header--${size}`, className]
		.filter(Boolean)
		.join(" ");

	return (
		<header className={headerClasses} role="banner">
			{titleContent
				? titleContent
				: title && (
						<MText
							text={title}
							as={titleProps.as || "h1"}
							size={titleProps.size || "xl"}
							weight={titleProps.weight || "bold"}
							className={["m-header__title", titleProps.className]
								.filter(Boolean)
								.join(" ")}
							{...titleProps}
						/>
				  )}
		</header>
	);
};

export default MHeader;
