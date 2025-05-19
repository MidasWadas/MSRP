import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Login.scss"; // Assuming you'll create a css file later

interface LoginFormData {
	email: string;
	password: string;
}

const Login: React.FC = () => {
	const [formData, setFormData] = useState<LoginFormData>({
		email: "",
		password: "",
	});
	const [error, setError] = useState<string | null>(null);
	const [isLoading, setIsLoading] = useState<boolean>(false);
	const navigate = useNavigate();

	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setFormData((prev) => ({
			...prev,
			[name]: value,
		}));
	};

	const handleSubmit = async (e: React.FormEvent) => {
		e.preventDefault();
		setError(null);
		setIsLoading(true);

		try {
			// const response = await fetch('/api/auth/login', {
			//     method: 'POST',
			//     headers: {
			//         'Content-Type': 'application/json',
			//     },
			//     body: JSON.stringify(formData),
			// });

			// if (!response.ok) {
			//     throw new Error('Invalid credentials');
			// }

			//const data = await response.json();

			//localStorage.setItem('token', data.token);
			navigate("/dashboard");
		} catch (err) {
			setError(err instanceof Error ? err.message : "Login failed");
		} finally {
			setIsLoading(false);
		}
	};

	return (
		<div className="login-container">
			<div className="login-form-wrapper">
				<h1>Login</h1>
				{error && <div className="error-message">{error}</div>}
				<form onSubmit={handleSubmit} className="login-form">
					<div className="form-group">
						<label htmlFor="email">Email</label>
						<input
							type="email"
							id="email"
							name="email"
							value={formData.email}
							onChange={handleChange}
							required
							placeholder="Enter your email"
						/>
					</div>
					<div className="form-group">
						<label htmlFor="password">Password</label>
						<input
							type="password"
							id="password"
							name="password"
							value={formData.password}
							onChange={handleChange}
							required
							placeholder="Enter your password"
						/>
					</div>
					<button
						type="submit"
						className="login-button"
						disabled={isLoading}
					>
						{isLoading ? "Logging in..." : "Login"}
					</button>
				</form>
				<div className="additional-options">
					<a href="/forgot-password">Forgot password?</a>
					<p>
						Don't have an account? <a href="/register">Register</a>
					</p>
				</div>
			</div>
		</div>
	);
};

export default Login;
