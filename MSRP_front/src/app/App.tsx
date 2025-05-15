import {
	BrowserRouter as Router,
	Routes,
	Route,
	Navigate,
} from "react-router-dom";
import { useState } from "react";
import Login from "../features/authorization/login/Login";
import Dashboard from "../features/dashboard/Dashboard";
import "./App.scss";
import Sidebar from "../features/sidebar/Sidebar";
import Recipes from "../features/recipes/Recipes";
import MealRandomizer from "../features/meal-randomizer/MealRandomizer";
import { mockRecipes } from "../mocks/recipes/mockRecipes";

const AuthenticatedLayout = ({ children }: { children: React.ReactNode }) => {
	return (
		<div className="app-container">
			<Sidebar username="John Doe" userRole="Administrator" />
			<div className="content-container">{children}</div>
		</div>
	);
};

function App() {
	const [isAuthenticated] = useState(true);

	return (
		<Router>
			<Routes>
				<Route
					path="/login"
					element={
						!isAuthenticated ? (
							<Login />
						) : (
							<Navigate to="/dashboard" />
						)
					}
				/>
				<Route
					path="/forgot-password"
					element={<div>Forgot Password Page</div>}
				/>
				<Route
					path="/reset-password"
					element={<div>Reset Password Page</div>}
				/>

				<Route
					path="/dashboard"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<Dashboard username="John Doe" />
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/recipes"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<Recipes />
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/randomizer"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<MealRandomizer recipes={mockRecipes} />
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/projects"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<div>Projects Page</div>
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/tasks"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<div>Tasks Page</div>
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/profile"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<div>Profile Page</div>
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>
				<Route
					path="/settings"
					element={
						isAuthenticated ? (
							<AuthenticatedLayout>
								<div>Settings Page</div>
							</AuthenticatedLayout>
						) : (
							<Navigate to="/login" />
						)
					}
				/>

				<Route
					path="*"
					element={
						<Navigate
							to={isAuthenticated ? "/dashboard" : "/login"}
						/>
					}
				/>
			</Routes>
		</Router>
	);
}

export default App;
