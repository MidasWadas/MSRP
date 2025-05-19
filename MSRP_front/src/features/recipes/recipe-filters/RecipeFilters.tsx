// import React, { useState, useEffect } from "react";
// import { FilterOptions } from "../Recipes";
// import MDropdown, {
// 	DropdownOption,
// } from "../../../components/organisms/MDropdown/MDropdown";
// import MRangeSlider from "../../../components/molecules/MRangeSlider/MRangeSlider";
// import MToggle from "../../../components/atoms/MToggle/MToggle";
// import MTag from "../../../components/molecules/MTag/MTag";
// import MText from "../../../components/atoms/MText/MText";
// import MSearchBar from "../../../components/molecules/MSearchbar/MSearchBar";
// import "./RecipeFilters.scss";
// import useCuisineOptions from "../../../hooks/useCuisineOptions";
// import useMealTypes from "../../../hooks/useMealTypes";
// import useDietaryOptions from "../../../hooks/useDietaryOptions";

// interface RecipeFiltersProps {
// 	filters: FilterOptions;
// 	onChange: (filters: FilterOptions) => void;
// 	onReset?: () => void;
// 	isExpanded?: boolean;
// 	onToggleExpand?: () => void;
// }

// const RecipeFilters: React.FC<RecipeFiltersProps> = ({
// 	filters,
// 	onChange,
// 	onReset,
// 	isExpanded = true,
// 	onToggleExpand,
// }) => {
// 	const [searchQuery, setSearchQuery] = useState<string>("");
// 	const { cuisineOptions: apiCuisineOptions, error: cuisineError } =
// 		useCuisineOptions();
// 	const { mealTypes: apiMealTypes, error: mealTypeError } = useMealTypes();
// 	const { dietaryOptions: apiDietaryOptions, error: dietaryError } =
// 		useDietaryOptions();

// 	// Show a console message if any API calls failed
// 	useEffect(() => {
// 		if (cuisineError || mealTypeError || dietaryError) {
// 			console.warn("Some API calls failed, using mock data:", {
// 				cuisineError,
// 				mealTypeError,
// 				dietaryError,
// 			});
// 		}
// 	}, [cuisineError, mealTypeError, dietaryError]);

// 	// Convert to format needed for dropdowns
// 	const cuisineDropdownOptions =
// 		apiCuisineOptions.length > 0
// 			? apiCuisineOptions.map((cuisine) => ({
// 					value: cuisine.id.toString(),
// 					label: cuisine.name,
// 			  }))
// 			: mockCuisineOptions;
// 	const mealTypeDropdownOptions =
// 		apiMealTypes.length > 0
// 			? apiMealTypes.map((type) => ({
// 					value: type.id.toString(),
// 					label: type.name,
// 			  }))
// 			: mockMealTypeOptions;

// 	const dietaryDropdownOptions =
// 		apiDietaryOptions.length > 0
// 			? apiDietaryOptions.map((diet) => ({
// 					value: diet.id.toString(),
// 					label: diet.name,
// 			  }))
// 			: mockDietaryOptions;

// 	// Handle filter changes
// 	const handleMealTypeChange = (selected: string[]) => {
// 		onChange({ ...filters, mealType: selected });
// 	};

// 	const handleCuisineChange = (selected: string[]) => {
// 		onChange({ ...filters, cuisineType: selected });
// 	};

// 	const handleDietaryChange = (selected: string[]) => {
// 		onChange({ ...filters, dietary: selected });
// 	};

// 	const handleDifficultyChange = (selected: string[]) => {
// 		onChange({ ...filters, difficultyLevel: selected });
// 	};

// 	const handleTimeChange = (value: number | [number, number]) => {
// 		onChange({
// 			...filters,
// 			maxPrepTime: typeof value === "number" ? value : value[1],
// 		});
// 	};

// 	const handleIngredientsToggle = (value: boolean) => {
// 		onChange({ ...filters, useAvailableIngredientsOnly: value });
// 	};

// 	const handleIngredientSearch = (query: string) => {
// 		console.log(`Searching for: ${query}`);
// 	};

// 	const handleRemoveFilter = (
// 		filterType: keyof FilterOptions,
// 		value: string
// 	) => {
// 		const currentValues = filters[filterType] as string[];
// 		if (Array.isArray(currentValues)) {
// 			onChange({
// 				...filters,
// 				[filterType]: currentValues.filter((item) => item !== value),
// 			});
// 		}
// 	};

// 	const handleResetFilters = () => {
// 		if (onReset) {
// 			onReset();
// 		} else {
// 			// Default reset behavior
// 			onChange({
// 				mealType: [],
// 				cuisineType: [],
// 				dietary: [],
// 				difficultyLevel: [],
// 				maxPrepTime: 60,
// 				useAvailableIngredientsOnly: false,
// 			});
// 		}
// 		setSearchQuery("");
// 	};
// 	const getActiveFilterCount = () => {
// 		let count = 0;

// 		if (filters.mealType?.length) count += filters.mealType.length;
// 		if (filters.cuisineType?.length) count += filters.cuisineType.length;
// 		if (filters.dietary?.length) count += filters.dietary.length;
// 		if (filters.difficultyLevel?.length)
// 			count += filters.difficultyLevel.length;
// 		if (filters.useAvailableIngredientsOnly) count += 1;
// 		if (filters.maxPrepTime !== 120) count += 1; // If not at max value

// 		return count;
// 	};

// 	const activeFilterCount = getActiveFilterCount();

// 	const findLabelForValue = (
// 		options: DropdownOption[],
// 		value: string
// 	): string => {
// 		const option = options.find((opt) => opt.value === value);
// 		return option ? option.label : value;
// 	};

// 	const getTagVariantForFilter = (
// 		filterType: string
// 	): "cuisine" | "meal" | "dietary" | "primary" => {
// 		switch (filterType) {
// 			case "mealType":
// 				return "meal";
// 			case "cuisineType":
// 				return "cuisine";
// 			case "dietary":
// 				return "dietary";
// 			default:
// 				return "primary";
// 		}
// 	};

// 	return (
// 		<div className="recipe-filters-panel">
// 			<div className="recipe-filters__header">
// 				<div className="recipe-filters__title-row">
// 					<MText
// 						as="h2"
// 						className="recipe-filters__title"
// 						text="Filter Recipes"
// 					/>
// 					{activeFilterCount > 0 && (
// 						<MTag
// 							label={activeFilterCount.toString()}
// 							variant="accent"
// 							size="small"
// 							className="recipe-filters__count"
// 						/>
// 					)}
// 				</div>

// 				{activeFilterCount > 0 && (
// 					<button
// 						className="recipe-filters__reset"
// 						onClick={handleResetFilters}
// 						aria-label="Reset all filters"
// 					>
// 						Reset
// 					</button>
// 				)}

// 				{onToggleExpand && (
// 					<button
// 						className="recipe-filters__toggle"
// 						onClick={onToggleExpand}
// 						aria-expanded={isExpanded}
// 					>
// 						{isExpanded ? "Collapse" : "Expand"}
// 					</button>
// 				)}
// 			</div>

// 			{isExpanded && (
// 				<div className="recipe-filters">
// 					<div className="filter-group">
// 						<MSearchBar
// 							searchLabel="Search ingredients..."
// 							value={searchQuery}
// 							onChange={setSearchQuery}
// 						/>
// 					</div>
// 					<div className="filter-group">
// 						<MDropdown
// 							label="Meal Type"
// 							options={mealTypeDropdownOptions}
// 							selected={filters.mealType}
// 							onChange={(selected) =>
// 								handleMealTypeChange(selected as string[])
// 							}
// 							multiSelect={true}
// 						/>
// 					</div>

// 					<div className="filter-group">
// 						<MDropdown
// 							label="Cuisine"
// 							options={cuisineDropdownOptions}
// 							selected={filters.cuisineType}
// 							onChange={(selected) =>
// 								handleCuisineChange(selected as string[])
// 							}
// 							multiSelect={true}
// 						/>
// 					</div>
// 					<div className="filter-group">
// 						<MDropdown
// 							label="Dietary Restrictions"
// 							options={dietaryDropdownOptions}
// 							selected={filters.dietary}
// 							onChange={(selected) =>
// 								handleDietaryChange(selected as string[])
// 							}
// 							multiSelect={true}
// 						/>
// 					</div>

// 					<div className="filter-group">
// 						<MDropdown
// 							label="Difficulty Level"
// 							options={difficultyOptions}
// 							selected={filters.difficultyLevel}
// 							onChange={(selected) =>
// 								handleDifficultyChange(selected as string[])
// 							}
// 							multiSelect={true}
// 						/>
// 					</div>

// 					<div className="filter-group">
// 						<h3 className="filter-section__title">Maximum Time</h3>
// 						<MRangeSlider
// 							min={10}
// 							max={120}
// 							value={filters.maxPrepTime || 60}
// 							onChange={handleTimeChange}
// 						/>
// 					</div>

// 					<div className="filter-group">
// 						<span className="toggle-label">
// 							Use Available Ingredients Only
// 						</span>
// 						<MToggle
// 							checked={filters.useAvailableIngredientsOnly}
// 							onChange={handleIngredientsToggle}
// 						/>
// 						<p className="helper-text">
// 							Show only recipes you can cook with items in your
// 							inventory
// 						</p>
// 					</div>
// 					<div className="active-filters">
// 						{filters.mealType?.map((value) => (
// 							<MTag
// 								key={value}
// 								label={findLabelForValue(
// 									mealTypeDropdownOptions,
// 									value
// 								)}
// 								variant={getTagVariantForFilter("mealType")}
// 								onRemove={() =>
// 									handleRemoveFilter("mealType", value)
// 								}
// 							/>
// 						))}
// 						{filters.cuisineType?.map((value) => (
// 							<MTag
// 								key={value}
// 								label={findLabelForValue(
// 									cuisineDropdownOptions,
// 									value
// 								)}
// 								variant={getTagVariantForFilter("cuisineType")}
// 								onRemove={() =>
// 									handleRemoveFilter("cuisineType", value)
// 								}
// 							/>
// 						))}{" "}
// 						{filters.dietary?.map((value) => (
// 							<MTag
// 								key={value}
// 								label={findLabelForValue(
// 									dietaryDropdownOptions,
// 									value
// 								)}
// 								variant={getTagVariantForFilter("dietary")}
// 								onRemove={() =>
// 									handleRemoveFilter("dietary", value)
// 								}
// 							/>
// 						))}
// 						{filters.difficultyLevel?.map((value) => (
// 							<MTag
// 								key={value}
// 								label={findLabelForValue(
// 									difficultyOptions,
// 									value
// 								)}
// 								variant={getTagVariantForFilter(
// 									"difficultyLevel"
// 								)}
// 								onRemove={() =>
// 									handleRemoveFilter("difficultyLevel", value)
// 								}
// 							/>
// 						))}
// 						{filters.useAvailableIngredientsOnly && (
// 							<MTag
// 								label="Available Ingredients Only"
// 								variant="primary"
// 								onRemove={() => handleIngredientsToggle(false)}
// 							/>
// 						)}
// 						{filters.maxPrepTime !== 120 && (
// 							<MTag
// 								label={`Max Time: ${filters.maxPrepTime} mins`}
// 								variant="primary"
// 								onRemove={() => handleTimeChange(120)}
// 							/>
// 						)}
// 					</div>
// 				</div>
// 			)}
// 		</div>
// 	);
// };

// export default RecipeFilters;
const RecipeFilters = () => {
	return null;
};
export default RecipeFilters;
