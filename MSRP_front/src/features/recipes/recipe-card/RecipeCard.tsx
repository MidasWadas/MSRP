import React from "react";
import { type Recipe } from "../recipes-list/types";
import MButton from "../../../components/atoms/MButton/MButton";
import MCard from "../../../components/molecules/MCard/MCard";
import "./RecipeCard.scss";
import MIconText from "../../../components/molecules/MIconText/MIconText";
import MText from "../../../components/atoms/MText/MText";
import {
	mockCuisineOptions,
	mockMealTypeOptions,
} from "../../../mocks/recipes/mockRecipes";
import useCuisineOptions from "../../../hooks/useCuisineOptions";
import useMealTypes from "../../../hooks/useMealTypes";

interface RecipeCardProps {
	recipe: Recipe;
	detailMode?: boolean;
	onFavoriteToggle?: (recipeId: number) => void;
	onClick?: () => void;
	onEdit?: () => void;
	onDelete?: () => void;
}

const RecipeCard: React.FC<RecipeCardProps> = ({
	recipe,
	detailMode = false,
	onFavoriteToggle,
	onClick,
	onEdit,
	onDelete,
}) => {
	const { cuisineOptions } = useCuisineOptions();
	const { mealTypes } = useMealTypes();

	const getCuisineName = (id: number): string => {
		const apiCuisine = cuisineOptions.find((c) => c.id === id);
		if (apiCuisine) return apiCuisine.name;

		const mockCuisine = mockCuisineOptions.find((c) => c.value === id);
		return mockCuisine?.label || "Unknown cuisine";
	};

	const getMealTypeName = (id: number): string => {
		const apiMealType = mealTypes.find((m) => m.id === id);
		if (apiMealType) return apiMealType.name;

		const mockMealType = mockMealTypeOptions.find((m) => m.value === id);
		return mockMealType?.label || "Unknown meal type";
	};

	const handleFavoriteClick = (e: React.MouseEvent) => {
		e.stopPropagation();
		if (onFavoriteToggle) {
			onFavoriteToggle(recipe.id);
		}
	};

	const handleEditClick = (e: React.MouseEvent) => {
		e.stopPropagation();
		if (onEdit) {
			onEdit();
		}
	};

	const handleDeleteClick = (e: React.MouseEvent) => {
		e.stopPropagation();
		if (onDelete) {
			onDelete();
		}
	};

	return (
		<div className="recipe-card-wrapper">
			{/* {onFavoriteToggle && (
				<MButton
					className={`favorite-button ${
						recipe.favorite ? "active" : ""
					}`}
					onClick={handleFavoriteClick}
					aria-label={
						recipe.favorite
							? "Remove from favorites"
							: "Add to favorites"
					}
					text={recipe.favorite ? "♥" : "♡"}
				/>
			)} */}
			<MCard
				className={`recipe-card ${detailMode ? "detail-mode" : ""}`}
				clickable={!detailMode && !!onClick}
				onClick={onClick}
				elevation={detailMode ? 2 : 1}
				title={recipe.title}
				subtitle={recipe.description}
				media={recipe.imageUrl}
				actions={
					!detailMode &&
					onEdit &&
					onDelete && (
						<div className="recipe-card-actions">
							<div className="m-card-actions">
								<MButton
									variant="outlined"
									size="small"
									onClick={handleEditClick}
									text="Edit"
								/>
								<MButton
									variant="error"
									size="small"
									onClick={handleDeleteClick}
									text="Delete"
								/>
							</div>
						</div>
					)
				}
			>
				<div className="m-card-content">
					<div className="recipe-meta">
						<MIconText
							icon="⏱️"
							placement="top"
							text={`Prep: \n${recipe.prepTime} min`}
							align="center"
							size="sm"
							className="meta-item"
						/>
						<MIconText
							icon="🍳"
							placement="top"
							text={`Cook:\n${recipe.cookTime} min`}
							align="center"
							size="sm"
							className="meta-item"
						/>
						<MIconText
							icon="👥"
							placement="top"
							text={`Serves: \n${recipe.servings}`}
							align="center"
							size="sm"
							className="meta-item"
						/>
					</div>
					<div className="recipe-tags">
						<MText
							className="tag meal-type"
							text={recipe.mealType.name}
						/>
						<MText
							className="tag cuisine"
							text={recipe.cuisine.name}
						/>
						{Array.isArray(recipe.dietaries) &&
							recipe.dietaries.length > 0 &&
							recipe.dietaries.map((diet, index) => (
								<MText
									key={index}
									className="tag dietary"
									text={diet.name}
								/>
							))}
					</div>

					{detailMode && (
						<div className="recipe-details compact-view">
							<div className="ingredients">
								<MText
									as="h3"
									color="primary"
									text="Ingredients"
								/>
								<ul className="ingredients-list">
									{recipe.ingredients.map(
										(ingredient, index) => (
											<li
												key={index}
												className="ingredient-item"
											>
												{ingredient}
											</li>
										)
									)}
								</ul>
							</div>

							<div className="instructions">
								<MText
									as="h3"
									color="primary"
									text="Instructions"
								/>
								<ol className="instructions-list">
									{recipe.instructions.map(
										(instruction, index) => (
											<li
												key={index}
												className="instruction-step"
											>
												{instruction}
											</li>
										)
									)}
								</ol>
							</div>
						</div>
					)}
				</div>
			</MCard>
		</div>
	);
};

export default RecipeCard;
