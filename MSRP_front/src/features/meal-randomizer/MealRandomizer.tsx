import React, { useState } from "react";
import RandomizerPanel from "../randomizer-panel/RandomizerPanel";
import RecipeCard from "../recipes/recipe-card/RecipeCard";
import EmptyState from "../empty-state/EmptyState";
import type { Recipe, FilterOptions } from "../recipes/Recipes";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";
import "./MealRandomizer.scss";
import useCuisineOptions from "hooks/useCuisineOptions";
import useMealTypes from "hooks/useMealTypes";
import useDietaryOptions from "hooks/useDietaryOptions";

interface MealRandomizerProps {
	recipes: Recipe[];
}

const MealRandomizer: React.FC<MealRandomizerProps> = ({ recipes }) => {
	const [selectedRecipe, setSelectedRecipe] = useState<Recipe | null>(null);
	const [isRandomizing, setIsRandomizing] = useState(false);
	const [filters, setFilters] = useState<FilterOptions>({
		mealType: [],
		cuisineType: [],
		dietary: [],
		maxPrepTime: null,
		difficultyLevel: [],
		useAvailableIngredientsOnly: false,
	});
	const { cuisineOptions } = useCuisineOptions();
	const { mealTypes } = useMealTypes();
	const { dietaryOptions } = useDietaryOptions();

	const onFavoriteToggle = () => {
		console.log("Favorite Toggled");
	};
	const getRandomRecipe = () => {
		setIsRandomizing(true);

		const filteredRecipes = recipes.filter((recipe) => {
			if (
				filters.mealType.length > 0 &&
				!filters.mealType.includes(recipe.mealType.id)
			) {
				return false;
			}

			if (
				filters.cuisineType.length > 0 &&
				!filters.cuisineType.includes(recipe.cuisine.id)
			) {
				return false;
			}

			if (
				filters.difficultyLevel.length > 0 &&
				!filters.difficultyLevel.includes(recipe.difficulty.id)
			) {
				return false;
			}
			if (
				filters.maxPrepTime &&
				recipe.prepTime + recipe.cookTime > filters.maxPrepTime
			) {
				return false;
			}

			if (filters.dietary.length > 0) {
				const hasDietary = filters.dietary.every((diet) =>
					recipe.dietary.some((d) => d.id === diet)
				);
				if (!hasDietary) return false;
			}

			return true;
		});

		setTimeout(() => {
			if (filteredRecipes.length > 0) {
				const randomIndex = Math.floor(
					Math.random() * filteredRecipes.length
				);
				setSelectedRecipe(filteredRecipes[randomIndex]);
			} else {
				setSelectedRecipe(null);
			}
			setIsRandomizing(false);
		}, 800);
	};

	const handleFiltersChange = (newFilters: FilterOptions) => {
		setFilters(newFilters);
	};

	const resetSelection = () => {
		setSelectedRecipe(null);
	};

	return (
		<div className="meal-randomizer">
			<div className="meal-randomizer-header">
				<MText text="Meal Randomizer" as="h1" size="xl" weight="bold" />
				<MButton
					text="Randomize Meal"
					onClick={getRandomRecipe}
					variant="accent"
				/>
			</div>
			<div className="meal-randomizer-body">
				<div className="randomizer-content">
					<div className="randomizer-sidebar">
						{/* <RecipeFilters
							filters={filters}
							onChange={handleFiltersChange}
						/> */}
					</div>

					<div className="randomizer-main">
						<RandomizerPanel
							onRandomize={getRandomRecipe}
							isRandomizing={isRandomizing}
							hasFilters={Object.values(filters).some((f) =>
								Array.isArray(f) ? f.length > 0 : !!f
							)}
							onReset={resetSelection}
						/>

						<div className="result-container">
							{isRandomizing ? (
								<div className="loading-state">
									Finding the perfect recipe for you...
								</div>
							) : selectedRecipe ? (
								<RecipeCard
									recipe={selectedRecipe}
									onFavoriteToggle={onFavoriteToggle}
									detailMode={true}
								/>
							) : (
								<EmptyState
									message="Click 'Surprise Me' to get a random recipe suggestion"
									icon="🍽️"
									action={{
										label: "Surprise Me!",
										onClick: getRandomRecipe,
									}}
								/>
							)}
						</div>
					</div>
				</div>
			</div>
		</div>
	);
};

export default MealRandomizer;
