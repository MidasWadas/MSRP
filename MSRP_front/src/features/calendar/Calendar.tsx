import React, { useState } from "react";
import "./Calendar.css";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";

const Calendar: React.FC = () => {
	const [currentMonth, setCurrentMonth] = useState(new Date());

	const monthNames = [
		"January",
		"February",
		"March",
		"April",
		"May",
		"June",
		"July",
		"August",
		"September",
		"October",
		"November",
		"December",
	];

	const weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

	const prevMonth = () => {
		const date = new Date(currentMonth);
		date.setMonth(date.getMonth() - 1);
		setCurrentMonth(date);
	};

	const nextMonth = () => {
		const date = new Date(currentMonth);
		date.setMonth(date.getMonth() + 1);
		setCurrentMonth(date);
	};

	const onAddEvent = () => {
		alert("Add Event clicked!");
	};

	return (
		<div className="calendar-container">
			<div className="calendar-header">
				<MText text="Calendar" as="h1" size="xl" weight="bold" />
				<MButton
					text="Add Event"
					onClick={onAddEvent}
					variant="primary"
				/>
			</div>
			<div className="calendar-body">
				<div className="weekdays-row">
					{weekDays.map((day) => (
						<div key={day} className="weekday">
							{day}
						</div>
					))}
				</div>

				<div className="calendar-grid">
					<div className="calendar-day">1</div>
					<div className="calendar-day">2</div>
					<div className="calendar-day">3</div>
					<div className="calendar-day today">4</div>
					<div className="calendar-day">5</div>
				</div>
			</div>
		</div>
	);
};

export default Calendar;
