import React, { useState, useEffect } from "react";
import { useSearchParams, useNavigate } from "react-router-dom";
import {
	TextField,
	Button,
	Typography,
	Box,
	Container,
	CircularProgress,
	Alert,
} from "@mui/material";

interface ResetPasswordForm {
	password: string;
	confirmPassword: string;
}

const ResetPassword: React.FC = () => {
	const [searchParams] = useSearchParams();
	const navigate = useNavigate();
	const [token, setToken] = useState<string | null>(null);
	const [loading, setLoading] = useState<boolean>(false);
	const [error, setError] = useState<string | null>(null);
	const [success, setSuccess] = useState<boolean>(false);
	const [formValues, setFormValues] = useState<ResetPasswordForm>({
		password: "",
		confirmPassword: "",
	});
	const [formErrors, setFormErrors] = useState<Partial<ResetPasswordForm>>(
		{}
	);

	useEffect(() => {
		const tokenParam = searchParams.get("token");
		if (!tokenParam) {
			setError("Invalid password reset link. Please request a new one.");
			return;
		}
		setToken(tokenParam);
	}, [searchParams]);

	const validateForm = (): boolean => {
		const errors: Partial<ResetPasswordForm> = {};

		if (!formValues.password) {
			errors.password = "Password is required";
		} else if (formValues.password.length < 8) {
			errors.password = "Password must be at least 8 characters long";
		}

		if (!formValues.confirmPassword) {
			errors.confirmPassword = "Please confirm your password";
		} else if (formValues.password !== formValues.confirmPassword) {
			errors.confirmPassword = "Passwords do not match";
		}

		setFormErrors(errors);
		return Object.keys(errors).length === 0;
	};

	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setFormValues({
			...formValues,
			[name]: value,
		});
	};

	const handleSubmit = async (e: React.FormEvent) => {
		e.preventDefault();

		if (!validateForm() || !token) return;

		setLoading(true);
		setError(null);

		try {
			await new Promise((resolve) => setTimeout(resolve, 1000));

			setSuccess(true);
			setTimeout(() => {
				navigate("/login");
			}, 3000);
		} catch (err) {
			setError(
				err instanceof Error ? err.message : "Failed to reset password"
			);
		} finally {
			setLoading(false);
		}
	};

	return (
		<Container maxWidth="sm">
			<Box
				sx={{
					mt: 8,
					display: "flex",
					flexDirection: "column",
					alignItems: "center",
				}}
			>
				<Typography component="h1" variant="h5">
					Reset Your Password
				</Typography>

				{error && (
					<Alert severity="error" sx={{ mt: 2, width: "100%" }}>
						{error}
					</Alert>
				)}

				{success ? (
					<Alert severity="success" sx={{ mt: 2, width: "100%" }}>
						Your password has been successfully reset. You will be
						redirected to the login page.
					</Alert>
				) : (
					<Box
						component="form"
						onSubmit={handleSubmit}
						sx={{ mt: 3, width: "100%" }}
					>
						<TextField
							margin="normal"
							required
							fullWidth
							name="password"
							label="New Password"
							type="password"
							id="password"
							autoComplete="new-password"
							value={formValues.password}
							onChange={handleChange}
							error={!!formErrors.password}
							helperText={formErrors.password}
						/>
						<TextField
							margin="normal"
							required
							fullWidth
							name="confirmPassword"
							label="Confirm New Password"
							type="password"
							id="confirmPassword"
							value={formValues.confirmPassword}
							onChange={handleChange}
							error={!!formErrors.confirmPassword}
							helperText={formErrors.confirmPassword}
						/>
						<Button
							type="submit"
							fullWidth
							variant="contained"
							sx={{ mt: 3, mb: 2 }}
							disabled={loading || !token}
						>
							{loading ? (
								<CircularProgress size={24} />
							) : (
								"Reset Password"
							)}
						</Button>
					</Box>
				)}
			</Box>
		</Container>
	);
};

export default ResetPassword;
