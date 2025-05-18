import React, { useState, useEffect } from "react";
import MModal from "@components/organisms/MModal/MModal";
import MButton from "@components/atoms/MButton/MButton";
import MInput from "@components/atoms/MInput/MInput";
import MSelect from "@components/atoms/MSelect/MSelect";
import MTextarea from "@components/atoms/MTextarea/MTextarea";
import MDropdown from "@components/organisms/MDropdown/MDropdown";
import RecipeCard from "@features/recipes/recipe-card/RecipeCard";
import { Recipe } from "@features/recipes/Recipes";
import "./RecipeModal.scss";
import { IdName } from "types/common";

interface RecipeModalProps {
	recipe: Recipe | null;
	isOpen: boolean;
	onClose: () => void;
	onSave?: (recipe: Recipe) => void;
	onDelete: (recipeId: number) => void;
	onFavoriteToggle: (recipeId: number) => void;
	mode: "view" | "edit";
	cuisineOptions: IdName[];
	mealTypes: IdName[];
	dietaryOptions: IdName[];
	difficultyOptions: IdName[];
}

const RecipeModal: React.FC<RecipeModalProps> = ({
	recipe,
	isOpen,
	onClose,
	onSave,
	onDelete,
	onFavoriteToggle,
	mode,
	cuisineOptions,
	mealTypes,
	dietaryOptions,
	difficultyOptions,
}) => {
	const [editedRecipe, setEditedRecipe] = useState<Recipe | null>(recipe);
	const [ingredientsText, setIngredientsText] = useState("");
	const [instructionsText, setInstructionsText] = useState("");
	const [selectedDietary, setSelectedDietary] = useState<number[]>([]);

	useEffect(() => {
		setEditedRecipe(recipe);
		if (recipe) {
			setIngredientsText(recipe.ingredients.join("\n"));
			setInstructionsText(recipe.instructions.join("\n"));
			setSelectedDietary(recipe.dietary.map((d) => d.id));
		}
	}, [recipe]);

	if (!editedRecipe) return null;

	const cuisineTypeId =
		typeof editedRecipe.cuisineType === "number"
			? editedRecipe.cuisineType
			: 1;

	const mealTypeId =
		typeof editedRecipe.mealType === "number" ? editedRecipe.mealType : 3;

	const handleSave = () => {
		if (onSave && editedRecipe) {
			onSave({
				...editedRecipe,
				ingredients: ingredientsText
					.split("\n")
					.filter((i) => i.trim() !== ""),
				instructions: instructionsText
					.split("\n")
					.filter((i) => i.trim() !== ""),
				dietary: selectedDietary.map((id) => ({
					id: id,
					name: dietaryOptions.find((option) => option.id === id)
						?.name!,
				})),
			});
		}
	};

	return (
		<MModal isOpen={isOpen} onClose={onClose} title="Recipe Details">
			{mode === "view" ? (
				<div className="recipe-detail-modal">
					<RecipeCard
						recipe={editedRecipe}
						onFavoriteToggle={onFavoriteToggle}
						detailMode
					/>
					<div className="modal-actions">
						<MButton
							variant="outlined"
							size="medium"
							onClick={() => onSave && onSave(editedRecipe)}
							text="Edit Recipe"
						/>
						<MButton
							variant="error"
							size="medium"
							onClick={() => onDelete(editedRecipe.id)}
							text="Delete Recipe"
						/>
					</div>
				</div>
			) : (
				<div className="recipe-edit-modal">
					<MInput
						label="Title"
						value={editedRecipe.title}
						onChange={(e) =>
							setEditedRecipe({
								...editedRecipe,
								title: e.target.value,
							})
						}
						required
						placeholder="Recipe title"
					/>

					<MTextarea
						label="Description"
						value={editedRecipe.description}
						onChange={(e) =>
							setEditedRecipe({
								...editedRecipe,
								description: e.target.value,
							})
						}
						placeholder="Brief description of the recipe"
						rows={3}
					/>

					<div className="form-row">
						<MInput
							label="Prep Time (min)"
							type="number"
							value={editedRecipe.prepTime}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									prepTime: parseInt(e.target.value) || 0,
								})
							}
							min={0}
						/>

						<MInput
							label="Cook Time (min)"
							type="number"
							value={editedRecipe.cookTime}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									cookTime: parseInt(e.target.value) || 0,
								})
							}
							min={0}
						/>

						<MInput
							label="Servings"
							type="number"
							value={editedRecipe.servings}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									servings: parseInt(e.target.value) || 1,
								})
							}
							min={1}
						/>
					</div>

					<div className="form-row">
						<MSelect
							label="Difficulty"
							value={editedRecipe.difficulty.id}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									difficulty: difficultyOptions.find(
										(option) =>
											option.id ===
											parseInt(e.target.value)
									)!,
								})
							}
							options={difficultyOptions}
						/>
						<MSelect
							label="Cuisine Type"
							value={editedRecipe.cuisineType.id}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									cuisineType: cuisineOptions.find(
										(option) =>
											option.id ===
											parseInt(e.target.value)
									)!,
								})
							}
							options={cuisineOptions}
						/>

						<MSelect
							label="Meal Type"
							value={editedRecipe.mealType.id}
							onChange={(e) =>
								setEditedRecipe({
									...editedRecipe,
									mealType: mealTypes.find(
										(option) =>
											option.id ===
											parseInt(e.target.value)
									)!,
								})
							}
							options={mealTypes}
						/>
					</div>

					<div className="ingredients-instructions-container">
						<MTextarea
							label="Ingredients (one per line)"
							value={ingredientsText}
							onChange={(e) => setIngredientsText(e.target.value)}
							rows={5}
							placeholder="Add each ingredient on a new line"
						/>

						<MTextarea
							label="Instructions (one per line)"
							value={instructionsText}
							onChange={(e) =>
								setInstructionsText(e.target.value)
							}
							rows={5}
							placeholder="Add each step on a new line"
						/>
					</div>

					<div className="form-row">
						<MDropdown
							label="Dietary Restrictions"
							options={dietaryOptions.map((option) => ({
								value: option.id,
								label: option.name,
							}))}
							selected={selectedDietary}
							onChange={(selected) =>
								setSelectedDietary(selected as number[])
							}
							multiSelect={true}
							fullWidth={true}
							searchable={true}
						/>
					</div>

					<MInput
						label="Image URL"
						type="url"
						value={editedRecipe.imageUrl}
						onChange={(e) =>
							setEditedRecipe({
								...editedRecipe,
								imageUrl: e.target.value,
							})
						}
						placeholder="https://example.com/image.jpg"
					/>

					<div className="form-actions">
						<MButton
							variant="text"
							onClick={onClose}
							text="Cancel"
						/>
						<MButton
							variant="primary"
							onClick={handleSave}
							text="Save Recipe"
						/>
					</div>
				</div>
			)}
		</MModal>
	);
};

export default RecipeModal;
