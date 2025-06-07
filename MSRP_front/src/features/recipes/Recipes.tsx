import React, { useState, useEffect } from "react";
import MHeader from "components/molecules/MHeader/MHeader";
import Text from "components/atoms/MText/MText";
import RecipeCard from "./recipe-card/RecipeCard";
import SearchBar from "components/molecules/MSearchbar/MSearchBar";
import EmptyState from "../empty-state/EmptyState";
import MButton from "components/atoms/MButton/MButton";
import MDropdown, {
	type DropdownOption,
} from "components/organisms/MDropdown/MDropdown";
import RecipeModal from "./recipe-modal/RecipeModal";
import {
	GridView,
	ViewList,
	GridViewOutlined,
	ViewCompactOutlined,
	ViewModuleOutlined,
} from "@mui/icons-material";
import "./recipes.scss";
import recipeService from "services/api/recipeService";
import type {
	RecipeFilterParams,
	CuisineOption,
	MealType,
	DifficultyOptions,
} from "services/api/recipeService";
import { mockRecipes } from "mocks/recipes/mockRecipes";
import useCuisineOptions from "hooks/useCuisineOptions";
import useMealTypes from "hooks/useMealTypes";
import useDifficultyOptions from "hooks/useDifficultyOptions";
import useDietaryOptions from "hooks/useDietaryOptions";
import { type IdName } from "types/common";

export interface Recipe {
	id: number;
	title: string;
	description: string;
	imageUrl: string;
	prepTime: number;
	cookTime: number;
	servings: number;
	difficulty: IdName;
	cuisineType: IdName;
	mealType: IdName;
	dietary: IdName[];
	ingredients: string[];
	instructions: string[];
	favorite: boolean;
}

export interface FilterOptions {
	mealType: number[];
	cuisineType: number[];
	dietary: number[];
	maxPrepTime: number | null;
	difficultyLevel: number[];
	useAvailableIngredientsOnly: boolean;
}

const Recipes: React.FC = () => {
	const [recipes, setRecipes] = useState<Recipe[]>([]);
	const [loading, setLoading] = useState<boolean>(true);
	const [error, setError] = useState<string | null>(null);
	const [searchQuery, setSearchQuery] = useState<string>("");
	const [selectedRecipe, setSelectedRecipe] = useState<Recipe | null>(null);
	const [isEditing, setIsEditing] = useState<boolean>(false);
	const [viewMode, setViewMode] = useState<"grid" | "list">("grid");
	const [sortBy, setSortBy] = useState<number>(0);
	const [filterBy, setFilterBy] = useState<{
		mealType: number[];
		cuisineType: number[];
		difficulty: number[];
	}>({
		mealType: [],
		cuisineType: [],
		difficulty: [],
	});
	const [cardSize, setCardSize] = useState<"small" | "medium" | "large">(
		"medium"
	);

	const {
		cuisineOptions,
		loading: loadingCuisineOptions,
		error: cuisineError,
	} = useCuisineOptions();
	const {
		mealTypes,
		loading: loadingMealTypes,
		error: mealTypeError,
	} = useMealTypes();
	const {
		dietaryOptions,
		loading: loadingDietaryOptions,
		error: dietaryError,
	} = useDietaryOptions();
	const {
		difficultyOptions,
		loading: loadingDifficultyOptions,
		error: difficultyError,
	} = useDifficultyOptions();

	const cuisineDropdownOptions: DropdownOption[] = cuisineOptions.map(
		(cuisine) => ({
			value: cuisine.id,
			label: cuisine.name,
		})
	);

	const mealTypeDropdownOptions: DropdownOption[] = mealTypes.map(
		(mealType) => ({
			value: mealType.id,
			label: mealType.name,
		})
	);

	const difficultyDropdownOptions: DropdownOption[] = difficultyOptions.map(
		(difficulty) => ({
			value: difficulty.id,
			label: difficulty.name,
		})
	);

	const sortOptions: DropdownOption[] = [
		{ value: 0, label: "Sort by Title" },
		{ value: 1, label: "Sort by Prep Time" },
		{ value: 2, label: "Sort by Cook Time" },
		{ value: 3, label: "Sort by Total Time" },
	];

	useEffect(() => {
		const fetchRecipes = async () => {
			setLoading(true);
			try {
				const filterParams: RecipeFilterParams = {
					mealType:
						filterBy.mealType.length > 0 ? filterBy.mealType : [],
					cuisineType:
						filterBy.cuisineType.length > 0
							? filterBy.cuisineType
							: [],
					difficulty:
						filterBy.difficulty.length > 0
							? filterBy.difficulty
							: [],
					searchQuery: searchQuery || undefined,
					sortBy,
				};

				//const data = await recipeService.getRecipes(filterParams);
				setRecipes(mockRecipes);
				setError(null);
			} catch (err) {
				console.error("Failed to fetch recipes:", err);
				setError("Failed to load recipes. Using mock data instead.");
				setRecipes(mockRecipes);
			} finally {
				setLoading(false);
			}
		};

		fetchRecipes();
	}, [searchQuery, filterBy, sortBy]);

	const handleAddRecipe = async () => {
		const newRecipe: Omit<Recipe, "id"> = {
			title: "New Recipe",
			description: "Add your description here",
			imageUrl: "https://via.placeholder.com/300x200",
			prepTime: 0,
			cookTime: 0,
			servings: 1,
			difficulty: difficultyOptions[0],
			cuisineType: cuisineOptions[0],
			mealType: mealTypes[0],
			dietary: [],
			ingredients: [],
			instructions: [],
			favorite: false,
		};

		try {
			const createdRecipe = await recipeService.createRecipe(newRecipe);
			setRecipes((prev) => [...prev, createdRecipe]);
			setSelectedRecipe(createdRecipe);
			setIsEditing(true);
		} catch (err) {
			console.error("Failed to create recipe:", err);
			const mockCreatedRecipe = {
				...newRecipe,
				id: Math.max(...recipes.map((r) => r.id)) + 1,
			};
			setRecipes((prev) => [...prev, mockCreatedRecipe]);
			setSelectedRecipe(mockCreatedRecipe);
			setIsEditing(true);
		}
	};

	const handleEditRecipe = (recipe: Recipe) => {
		setSelectedRecipe(recipe);
		setIsEditing(true);
	};

	const handleSaveRecipe = async (updatedRecipe: Recipe) => {
		try {
			const savedRecipe = await recipeService.updateRecipe(
				updatedRecipe.id,
				updatedRecipe
			);
			setRecipes((prevRecipes) =>
				prevRecipes.map((recipe) =>
					recipe.id === savedRecipe.id ? savedRecipe : recipe
				)
			);
			setSelectedRecipe(savedRecipe);
			//await recipeService.createRecipe(updatedRecipe);
			setIsEditing(false);
		} catch (err) {
			console.error("Failed to update recipe:", err);
			setRecipes((prevRecipes) =>
				prevRecipes.map((recipe) =>
					recipe.id === updatedRecipe.id ? updatedRecipe : recipe
				)
			);
			setSelectedRecipe(updatedRecipe);
			setIsEditing(false);
		}
	};

	const handleDeleteRecipe = async (recipeId: number) => {
		try {
			await recipeService.deleteRecipe(recipeId);
			setRecipes((prevRecipes) =>
				prevRecipes.filter((recipe) => recipe.id !== recipeId)
			);
			if (selectedRecipe && selectedRecipe.id === recipeId) {
				setSelectedRecipe(null);
				setIsEditing(false);
			}
		} catch (err) {
			console.error("Failed to delete recipe:", err);
			setRecipes((prevRecipes) =>
				prevRecipes.filter((recipe) => recipe.id !== recipeId)
			);
			if (selectedRecipe && selectedRecipe.id === recipeId) {
				setSelectedRecipe(null);
				setIsEditing(false);
			}
		}
	};

	const toggleFavorite = async (recipeId: number) => {
		const recipe = recipes.find((r) => r.id === recipeId);
		if (!recipe) return;

		const newFavoriteStatus = !recipe.favorite;

		try {
			await recipeService.updateRecipe(recipeId, recipe);
			setRecipes((prevRecipes) =>
				prevRecipes.map((recipe) =>
					recipe.id === recipeId
						? { ...recipe, favorite: newFavoriteStatus }
						: recipe
				)
			);
		} catch (err) {
			console.error("Failed to update favorite status:", err);
			setRecipes((prevRecipes) =>
				prevRecipes.map((recipe) =>
					recipe.id === recipeId
						? { ...recipe, favorite: newFavoriteStatus }
						: recipe
				)
			);
		}
	};

	const handleFilterChange = (
		filterType: "mealType" | "cuisineType" | "difficulty",
		values: number[]
	) => {
		setFilterBy((prev) => ({
			...prev,
			[filterType]: values,
		}));
	};

	const handleSearch = (query: string) => {
		setSearchQuery(query);
	};

	const handleSortChange = (values: number[]) => {
		if (values.length > 0) {
			setSortBy(values[0]);
		}
	};

	return (
		<div className="recipes-container">
			<MHeader
				title="Recipe Collection"
				className="recipes-header"
				size="large"
			/>
			<Text
				className="recipes-header__subtext"
				text="Manage your favorite recipes and cooking instructions"
			/>

			<div className="recipes-toolbar">
				<div className="toolbar-top">
					<MButton
						onClick={handleAddRecipe}
						variant="primary"
						className="add-recipe-button"
					>
						Add Recipe
					</MButton>

					<SearchBar
						searchLabel="Find recipes by name..."
						value={searchQuery}
						onChange={handleSearch}
						className="search-bar"
						compact={true}
					/>
					<div className="view-controls">
						<MButton
							className={viewMode === "grid" ? "active" : ""}
							onClick={() => setViewMode("grid")}
							aria-label="Grid view"
							variant="outlined"
							size="small"
							icon={<GridView />}
							showAsIcon={true}
						/>
						<MButton
							className={viewMode === "list" ? "active" : ""}
							onClick={() => setViewMode("list")}
							aria-label="List view"
							variant="outlined"
							size="small"
							icon={<ViewList />}
							showAsIcon={true}
						/>

						{viewMode === "grid" && (
							<div className="card-size-controls">
								<MButton
									className={
										cardSize === "small" ? "active" : ""
									}
									onClick={() => setCardSize("small")}
									aria-label="Small card size"
									variant="outlined"
									size="small"
									icon={<ViewCompactOutlined />}
									showAsIcon={true}
								/>
								<MButton
									className={
										cardSize === "medium" ? "active" : ""
									}
									onClick={() => setCardSize("medium")}
									aria-label="Medium card size"
									variant="outlined"
									size="small"
									icon={<ViewModuleOutlined />}
									showAsIcon={true}
								/>
								<MButton
									className={
										cardSize === "large" ? "active" : ""
									}
									onClick={() => setCardSize("large")}
									aria-label="Large card size"
									variant="outlined"
									size="small"
									icon={<GridViewOutlined />}
									showAsIcon={true}
								/>
							</div>
						)}
					</div>
				</div>
				<div className="recipes-filters-panel">
					<div className="recipes-filters">
						{" "}
						<div className="filter-group">
							<MDropdown
								label="Meal Type"
								options={mealTypeDropdownOptions}
								selected={filterBy.mealType}
								onChange={(values) =>
									handleFilterChange(
										"mealType",
										values as number[]
									)
								}
								multiSelect={true}
							/>
						</div>
						<div className="filter-group">
							<MDropdown
								label="Cuisine"
								options={cuisineDropdownOptions}
								selected={filterBy.cuisineType}
								onChange={(values) =>
									handleFilterChange(
										"cuisineType",
										values as number[]
									)
								}
								multiSelect={true}
							/>
						</div>
						<div className="filter-group">
							<MDropdown
								label="Difficulty"
								options={difficultyDropdownOptions}
								selected={filterBy.difficulty}
								onChange={(values) =>
									handleFilterChange(
										"difficulty",
										values as number[]
									)
								}
								multiSelect={true}
							/>
						</div>
						<div className="filter-group">
							<MDropdown
								label="Sort"
								options={sortOptions}
								selected={[sortBy]}
								onChange={(value) => {
									if (
										Array.isArray(value) &&
										value.length > 0
									) {
										setSortBy(value[0]);
									} else if (typeof value === "string") {
										setSortBy(value);
									}
								}}
								multiSelect={false}
							/>
						</div>
					</div>
				</div>{" "}
			</div>

			{loading ? (
				<div className="loading-container">
					<p>Loading recipes...</p>
				</div>
			) : error ? (
				<div className="error-container">
					<p>{error}</p>
				</div>
			) : (
				<div
					className={`recipes-grid recipes-grid--${cardSize} ${
						viewMode === "list" ? "list-view" : ""
					}`}
				>
					{recipes.length > 0 ? (
						recipes.map((recipe) => (
							<div className="recipe-item" key={recipe.id}>
								<RecipeCard
									recipe={recipe}
									onFavoriteToggle={toggleFavorite}
									detailMode={false}
									onClick={() => setSelectedRecipe(recipe)}
									onEdit={() => handleEditRecipe(recipe)}
									onDelete={() =>
										handleDeleteRecipe(recipe.id)
									}
								/>
							</div>
						))
					) : (
						<EmptyState
							message={
								searchQuery
									? "No recipes found matching your search"
									: "No recipes added yet"
							}
							icon="📝"
							action={
								searchQuery
									? {
											label: "Clear Search",
											onClick: () => setSearchQuery(""),
									  }
									: {
											label: "Add Your First Recipe",
											onClick: handleAddRecipe,
									  }
							}
						/>
					)}
				</div>
			)}

			<RecipeModal
				recipe={selectedRecipe}
				isOpen={!!selectedRecipe}
				onClose={() => {
					if (isEditing) {
						setIsEditing(false);
					} else {
						setSelectedRecipe(null);
					}
				}}
				onSave={isEditing ? handleSaveRecipe : () => setIsEditing(true)}
				onDelete={handleDeleteRecipe}
				onFavoriteToggle={toggleFavorite}
				mode={isEditing ? "edit" : "view"}
				dietaryOptions={dietaryOptions}
				mealTypes={mealTypes}
				difficultyOptions={difficultyOptions}
				cuisineOptions={cuisineOptions}
			/>
		</div>
	);
};

export default Recipes;
