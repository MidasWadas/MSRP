import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import "./Sidebar.scss";
import MButton from "../../components/atoms/MButton/MButton";
import {
	Dashboard,
	Restaurant,
	RestaurantMenu,
	Task,
	Person,
	Settings,
	Logout,
	ChevronLeft,
	ChevronRight,
} from "@mui/icons-material";

interface SidebarProps {
	username?: string;
	userRole?: string;
}

const Sidebar: React.FC<SidebarProps> = ({
	username = "User",
	userRole = "Member",
}) => {
	const [collapsed, setCollapsed] = useState(false);

	const toggleSidebar = () => {
		setCollapsed(!collapsed);
	};

	return (
		<div className={`sidebar ${collapsed ? "collapsed" : ""}`}>
			<div className="sidebar-header">
				<div className="logo">
					<h2>{collapsed ? "M" : "MSRP"}</h2>
				</div>
				<MButton className="toggle-btn" onClick={toggleSidebar}>
					{collapsed ? <ChevronRight /> : <ChevronLeft />}
				</MButton>
			</div>

			<div className="user-info">
				<div className="avatar">{username.charAt(0).toUpperCase()}</div>
				{!collapsed && (
					<div className="user-details">
						<h3>{username}</h3>
						<p>{userRole}</p>
					</div>
				)}
			</div>

			<nav className="sidebar-nav">
				<ul>
					<li>
						<NavLink
							to="/dashboard"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Dashboard />
							{!collapsed && <span>Dashboard</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/recipes"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Restaurant />
							{!collapsed && <span>Recipes</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/randomizer"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<RestaurantMenu />
							{!collapsed && <span>Meal Randomizer</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/projects"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Task />
							{!collapsed && <span>Projects</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/tasks"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Task />
							{!collapsed && <span>Tasks</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/profile"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Person />
							{!collapsed && <span>Profile</span>}
						</NavLink>
					</li>
					<li>
						<NavLink
							to="/settings"
							className={({ isActive }) =>
								isActive ? "active" : ""
							}
						>
							<Settings />
							{!collapsed && <span>Settings</span>}
						</NavLink>
					</li>
				</ul>
			</nav>

			<div className="sidebar-footer">
				<MButton
					className="logout-btn"
					onClick={() => console.log("Logout")}
				>
					<Logout />
					{!collapsed && <span>Logout</span>}
				</MButton>
			</div>
		</div>
	);
};

export default Sidebar;
