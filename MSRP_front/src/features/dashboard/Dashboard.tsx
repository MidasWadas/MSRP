import React, { useState, useEffect } from "react";
import MHeader from "../../components/molecules/MHeader/MHeader";
import MText from "../../components/atoms/MText/MText";
import MCard from "../../components/molecules/MCard/MCard";
import MButton from "../../components/atoms/MButton/MButton";
import "./Dashboard.scss";

interface DashboardProps {
	username?: string;
}

interface SummaryData {
	totalProjects: number;
	activeProjects: number;
	completedProjects: number;
	pendingTasks: number;
}

const Dashboard: React.FC<DashboardProps> = ({ username = "User" }) => {
	const [summaryData, setSummaryData] = useState<SummaryData>({
		totalProjects: 0,
		activeProjects: 0,
		completedProjects: 0,
		pendingTasks: 0,
	});

	const [isLoading, setIsLoading] = useState<boolean>(true);

	useEffect(() => {
		setTimeout(() => {
			setSummaryData({
				totalProjects: 12,
				activeProjects: 5,
				completedProjects: 7,
				pendingTasks: 15,
			});
			setIsLoading(false);
		}, 1000);

		// fetchDashboardData().then(data => {
		//   setSummaryData(data);
		//   setIsLoading(false);
		// });
	}, []);

	const dashboardLogo = (
		<span className="icon" style={{ marginRight: 12 }}>
			📊
		</span>
	);

	return (
		<div className="dashboard-container">
			<MHeader
				titleContent={
					<span style={{ display: "flex", alignItems: "center" }}>
						{dashboardLogo}
						{`Welcome, ${username}`}
					</span>
				}
				className="dashboard-header"
			/>
			<MText
				text="Here's an overview of your projects and tasks"
				as="div"
				size="md"
				color="muted"
				className="dashboard-header__subtext"
			/>
			{isLoading ? (
				<MText
					text="Loading dashboard data..."
					as="div"
					size="md"
					color="muted"
					className="loading-indicator"
				/>
			) : (
				<>
					<section className="summary-cards">
						<MCard
							title="Total Projects"
							titleProps={{
								as: "h3",
								size: "md",
								weight: "bold",
								className: "card-title",
							}}
						>
							<MText
								text={String(summaryData.totalProjects)}
								as="div"
								size="xl"
								weight="bold"
								className="card-value"
							/>
						</MCard>
						<MCard
							title="Active Projects"
							titleProps={{
								as: "h3",
								size: "md",
								weight: "bold",
								className: "card-title",
							}}
						>
							<MText
								text={String(summaryData.activeProjects)}
								as="div"
								size="xl"
								weight="bold"
								className="card-value"
							/>
						</MCard>
						<MCard
							title="Completed"
							titleProps={{
								as: "h3",
								size: "md",
								weight: "bold",
								className: "card-title",
							}}
						>
							<MText
								text={String(summaryData.completedProjects)}
								as="div"
								size="xl"
								weight="bold"
								className="card-value"
							/>
						</MCard>
						<MCard
							title="Pending Tasks"
							titleProps={{
								as: "h3",
								size: "md",
								weight: "bold",
								className: "card-title",
							}}
						>
							<MText
								text={String(summaryData.pendingTasks)}
								as="div"
								size="xl"
								weight="bold"
								className="card-value"
							/>
						</MCard>
					</section>
					<section className="dashboard-content">
						<div className="chart-container">
							<MText
								text="Project Progress"
								as="h2"
								size="lg"
								weight="bold"
								className="section-title"
							/>
							<div className="chart-placeholder">
								<MText
									text="Chart will be displayed here"
									as="div"
									size="md"
									color="muted"
									className="placeholder-text"
								/>
							</div>
						</div>
						<div className="recent-activity">
							<MText
								text="Recent Activity"
								as="h2"
								size="lg"
								weight="bold"
								className="section-title"
							/>
							<ul className="activity-list">
								<li>Project "Website Redesign" was updated</li>
								<li>You completed 3 tasks today</li>
								<li>New comment on "Mobile App Development"</li>
								<li>
									Task deadline approaching: "Submit
									Documentation"
								</li>
							</ul>
						</div>
					</section>
					<section className="quick-actions">
						<MText
							text="Quick Actions"
							as="h2"
							size="lg"
							weight="bold"
							className="section-title"
						/>
						<div className="action-buttons">
							<MButton text="Create New Project" />
							<MButton text="Add Task" />
							<MButton text="Generate Report" />
						</div>
					</section>
				</>
			)}
		</div>
	);
};

export default Dashboard;
