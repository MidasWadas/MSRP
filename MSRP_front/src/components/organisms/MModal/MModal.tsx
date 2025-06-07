import React, { useEffect, useRef, useState } from "react";
import ReactDOM from "react-dom";
import "./mmodal.scss";
import { buildClassNames } from "utils/classNameUtils";
import MText, { type MTextProps } from "components/atoms/MText/MText";
import MButton, { type MButtonProps } from "components/atoms/MButton/MButton";

interface MModalProps {
	isOpen: boolean;
	onClose: () => void;
	children: React.ReactNode;
	className?: string;
	title?: string;
	titleProps?: Partial<MTextProps>;
	closeButtonProps?: Partial<MButtonProps>;
}

const MModal: React.FC<MModalProps> = ({
	isOpen,
	onClose,
	children,
	className = "",
	title,
	titleProps = {},
	closeButtonProps = {},
}) => {
	const [isAnimating, setIsAnimating] = useState(false);
	const [isVisible, setIsVisible] = useState(false);
	const modalRef = useRef<HTMLDivElement>(null);
	const previouslyFocusedElement = useRef<HTMLElement | null>(null);

	useEffect(() => {
		if (isOpen && !isVisible) {
			setIsVisible(true);
			setIsAnimating(true);

			previouslyFocusedElement.current =
				document.activeElement as HTMLElement;

			const timer = setTimeout(() => {
				setIsAnimating(false);
			}, 300);

			return () => clearTimeout(timer);
		} else if (!isOpen && isVisible) {
			setIsAnimating(true);

			const timer = setTimeout(() => {
				setIsVisible(false);
				setIsAnimating(false);
			}, 300);

			return () => clearTimeout(timer);
		}
	}, [isOpen, isVisible]);

	useEffect(() => {
		if (isVisible) {
			const currentPadding =
				parseInt(window.getComputedStyle(document.body).paddingRight) ||
				0;

			const scrollBarWidth =
				window.innerWidth - document.documentElement.clientWidth;

			document.body.style.paddingRight = `${
				currentPadding + scrollBarWidth
			}px`;
			document.body.style.overflow = "hidden";

			if (modalRef.current) {
				setTimeout(() => {
					const focusableElements =
						modalRef.current?.querySelectorAll(
							'button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])'
						);

					if (focusableElements && focusableElements.length) {
						(focusableElements[0] as HTMLElement).focus();
					} else {
						modalRef.current?.focus();
					}
				}, 50);
			}
		}

		return () => {
			document.body.style.paddingRight = "";
			document.body.style.overflow = "";

			if (isVisible && previouslyFocusedElement.current) {
				previouslyFocusedElement.current.focus();
			}
		};
	}, [isVisible]);

	const handleKeyDown = (event: React.KeyboardEvent) => {
		if (event.key === "Tab") {
			if (!modalRef.current) return;

			const focusableElements = Array.from(
				modalRef.current.querySelectorAll(
					'button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])'
				)
			);

			if (focusableElements.length === 0) return;

			const firstFocusable = focusableElements[0] as HTMLElement;
			const lastFocusable = focusableElements[
				focusableElements.length - 1
			] as HTMLElement;

			if (event.shiftKey && document.activeElement === firstFocusable) {
				lastFocusable.focus();
				event.preventDefault();
			} else if (
				!event.shiftKey &&
				document.activeElement === lastFocusable
			) {
				firstFocusable.focus();
				event.preventDefault();
			}
		}

		if (event.key === "Escape") {
			onClose();
		}
	};

	const handleBackdropClick = (e: React.MouseEvent<HTMLDivElement>) => {
		if (e.target === e.currentTarget) {
			onClose();
		}
	};

	if (!isVisible) return null;

	const modalClasses = buildClassNames([
		"m-modal",
		isAnimating && !isOpen && "m-modal--closing",
		isAnimating && isOpen && "m-modal--opening",
		className,
	]);

	const backdropClasses = buildClassNames([
		"m-modal__backdrop",
		isAnimating && !isOpen && "m-modal__backdrop--closing",
	]);

	const contentClasses = buildClassNames(["m-modal__content"]);

	const modal = (
		<div className={backdropClasses} onClick={handleBackdropClick}>
			<div
				ref={modalRef}
				className={modalClasses}
				role="dialog"
				aria-modal="true"
				onKeyDown={handleKeyDown}
				tabIndex={-1}
			>
				{(title || closeButtonProps) && (
					<div className="m-modal__header">
						{title && (
							<MText
								text={title}
								as={titleProps.as || "h2"}
								size={titleProps.size || "lg"}
								weight={titleProps.weight || "bold"}
								className={[
									"m-modal__title",
									titleProps.className,
								]
									.filter(Boolean)
									.join(" ")}
								{...titleProps}
							/>
						)}
						<MButton
							variant={closeButtonProps.variant || "text"}
							size={closeButtonProps.size || "small"}
							icon={
								closeButtonProps.icon || (
									<svg
										xmlns="http://www.w3.org/2000/svg"
										width="16"
										height="16"
										viewBox="0 0 24 24"
										fill="none"
										stroke="currentColor"
										strokeWidth="2"
										strokeLinecap="round"
										strokeLinejoin="round"
									>
										<line
											x1="18"
											y1="6"
											x2="6"
											y2="18"
										></line>
										<line
											x1="6"
											y1="6"
											x2="18"
											y2="18"
										></line>
									</svg>
								)
							}
							showAsIcon
							aria-label="Close"
							className={[
								"m-modal__close",
								closeButtonProps.className,
							]
								.filter(Boolean)
								.join(" ")}
							onClick={onClose}
							{...closeButtonProps}
						/>
					</div>
				)}
				<div className={contentClasses}>{children}</div>
			</div>
		</div>
	);

	return ReactDOM.createPortal(modal, document.body);
};

export default MModal;
