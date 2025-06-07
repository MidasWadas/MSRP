import { type Recipe } from "../../features/recipes/Recipes";
import { type DropdownOption } from "../../components/organisms/MDropdown/MDropdown";

// Meal type options for mocking - matching backend seeded data
export const mockMealTypeOptions: DropdownOption[] = [
	{ value: 1, label: "Breakfast" },
	{ value: 2, label: "Lunch" },
	{ value: 3, label: "Dinner" },
	{ value: 4, label: "Snack" },
	{ value: 5, label: "Dessert" },
];

// Difficulty options - using numerical values to match backend enum
export const mockDifficultyOptions: DropdownOption[] = [
	{ value: 0, label: "Easy" },
	{ value: 1, label: "Medium" },
	{ value: 2, label: "Hard" },
];

// Cuisine type options for mocking - matching backend seeded data
export const mockCuisineOptions: DropdownOption[] = [
	{ value: 1, label: "Italian" },
	{ value: 2, label: "Mexican" },
	{ value: 3, label: "Japanese" },
	{ value: 4, label: "Indian" },
	{ value: 5, label: "Mediterranean" },
];

// Dietary restriction options for mocking - matching backend seeded data
export const mockDietaryOptions: DropdownOption[] = [
	{
		value: 1,
		label: "Vegetarian",
		description: "No meat, poultry, or seafood",
	},
	{ value: 2, label: "Vegan", description: "No animal products" },
	{
		value: 3,
		label: "Gluten-Free",
		description: "No gluten-containing ingredients",
	},
	{ value: 4, label: "Dairy-Free", description: "No dairy products" },
];

export const mockRecipes: Recipe[] = [
	{
		id: 1,
		title: "Spaghetti Carbonara",
		description:
			"A classic Italian pasta dish with eggs, cheese, and pancetta.",
		imageUrl:
			"https://www.sipandfeast.com/wp-content/uploads/2022/09/spaghetti-carbonara-recipe-snippet.jpg",
		prepTime: 10,
		cookTime: 15,
		servings: 4,
		difficulty: { id: 1, name: "Medium" },
		cuisineType: { id: 1, name: "Italian" },
		mealType: { id: 3, name: "Dinner" },
		dietary: [
			{ id: 4, name: "Dairy-Free" },
			{ id: 3, name: "Gluten-Free" },
		],
		ingredients: [
			"Spaghetti",
			"Eggs",
			"Pancetta",
			"Parmesan",
			"Black pepper",
		],
		instructions: [
			"Boil pasta",
			"Cook pancetta",
			"Mix eggs and cheese",
			"Combine everything",
		],
		favorite: true,
	},
	{
		id: 2,
		title: "Avocado Toast",
		description:
			"Simple and nutritious breakfast with avocado on toasted bread.",
		imageUrl:
			"https://www.allrecipes.com/thmb/8NccFzsaq0_OZPDKmf7Yee-aG78=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AvocadoToastwithEggFranceC4x3-bb87e3bbf1944657b7db35f1383fabdb.jpg",
		prepTime: 5,
		cookTime: 5,
		servings: 1,
		difficulty: { id: 0, name: "Easy" },
		cuisineType: { id: 5, name: "Mediterranean" },
		mealType: { id: 1, name: "Breakfast" },
		dietary: [{ id: 1, name: "Vegetarian" }],
		ingredients: ["Bread", "Avocado", "Salt", "Pepper", "Olive oil"],
		instructions: [
			"Toast bread",
			"Mash avocado",
			"Spread on toast",
			"Season to taste",
		],
		favorite: false,
	},
	{
		id: 3,
		title: "Chicken Curry",
		description: "Spicy and aromatic curry with tender chicken pieces.",
		imageUrl:
			"https://kitchenofdebjani.com/wp-content/uploads/2023/04/easy-indian-chicken-curry-Recipe-for-beginners-Debjanir-rannaghar.jpg",
		prepTime: 15,
		cookTime: 30,
		servings: 4,
		difficulty: { id: 1, name: "Medium" },
		cuisineType: { id: 4, name: "Indian" },
		mealType: { id: 3, name: "Dinner" },
		dietary: [
			{ id: 3, name: "Gluten-Free" },
			{ id: 4, name: "Dairy-Free" },
		],
		ingredients: [
			"Chicken",
			"Curry powder",
			"Coconut milk",
			"Onion",
			"Garlic",
		],
		instructions: [
			"Cook onions and garlic",
			"Add chicken",
			"Add spices",
			"Simmer with coconut milk",
		],
		favorite: true,
	},
	{
		id: 4,
		title: "Vegetable Stir Fry",
		description:
			"A quick and colorful vegetarian stir fry loaded with fresh vegetables.",
		imageUrl:
			"https://www.budgetbytes.com/wp-content/uploads/2022/03/Easy-Vegetable-Stir-Fry-V1-768x1024.jpg",
		prepTime: 15,
		cookTime: 10,
		servings: 4,
		difficulty: { id: 0, name: "Easy" },
		cuisineType: { id: 3, name: "Japanese" },
		mealType: { id: 3, name: "Dinner" },
		dietary: [
			{ id: 1, name: "Vegetarian" },
			{ id: 2, name: "Vegan" },
			{ id: 4, name: "Dairy-Free" },
		],
		ingredients: [
			"Bell peppers",
			"Broccoli",
			"Carrots",
			"Snow peas",
			"Tofu",
			"Soy sauce",
			"Garlic",
			"Ginger",
			"Sesame oil",
		],
		instructions: [
			"Prepare vegetables",
			"Press and cube tofu",
			"Heat oil in wok",
			"Stir-fry garlic and ginger",
			"Add vegetables",
			"Add tofu and sauce",
			"Serve hot",
		],
		favorite: false,
	},
	{
		id: 5,
		title: "Gluten-Free Banana Pancakes",
		description:
			"Fluffy pancakes made with oat flour and ripe bananas, perfect for a weekend breakfast.",
		imageUrl:
			"https://simple-veganista.com/wp-content/uploads/2013/03/almond-flour-banana-vegan-gluten-free-pancakes-recipe-11.jpg",
		prepTime: 10,
		cookTime: 15,
		servings: 2,
		difficulty: { id: 0, name: "Easy" },
		cuisineType: { id: 5, name: "Mediterranean" },
		mealType: { id: 1, name: "Breakfast" },
		dietary: [
			{ id: 3, name: "Gluten-Free" },
			{ id: 1, name: "Vegetarian" },
		],
		ingredients: [
			"Ripe bananas",
			"Eggs",
			"Oat flour",
			"Cinnamon",
			"Baking powder",
			"Salt",
			"Vanilla extract",
			"Maple syrup",
		],
		instructions: [
			"Mash bananas",
			"Mix with eggs and vanilla",
			"Add dry ingredients",
			"Cook on griddle",
			"Flip when bubbles form",
			"Serve with maple syrup",
		],
		favorite: true,
	},
	{
		id: 6,
		title: "Chocolate Lava Cake",
		description:
			"Decadent individual chocolate cakes with a gooey molten center.",
		imageUrl:
			"https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/39E92D31-D1AE-44DC-8B86-C60A8E6B8D05/Derivates/744B2C83-F33A-4AB5-A7DD-0D59D555D0F6.jpg",
		prepTime: 15,
		cookTime: 12,
		servings: 4,
		difficulty: { id: 2, name: "Medium" },
		cuisineType: { id: 1, name: "Italian" },
		mealType: { id: 5, name: "Dessert" },
		dietary: [
			{ id: 4, name: "Dairy-Free" },
			{ id: 3, name: "Gluten-Free" },
		],
		ingredients: [
			"Dark chocolate",
			"Butter",
			"Eggs",
			"Sugar",
			"Flour",
			"Vanilla extract",
			"Salt",
		],
		instructions: [
			"Melt chocolate and butter",
			"Whisk eggs and sugar",
			"Combine mixtures",
			"Add flour",
			"Pour into ramekins",
			"Bake until edges are set",
			"Serve immediately",
		],
		favorite: false,
	},
	{
		id: 7,
		title: "Mediterranean Quinoa Bowl",
		description:
			"Nutritious lunch bowl with quinoa, fresh vegetables, feta, and hummus.",
		imageUrl:
			"https://thealmondeater.com/wp-content/uploads/2022/06/mediterranean-quinoa-bowl_web-3.jpg",
		prepTime: 20,
		cookTime: 15,
		servings: 2,
		difficulty: { id: 0, name: "Easy" },
		cuisineType: { id: 5, name: "Mediterranean" },
		mealType: { id: 2, name: "Lunch" },
		dietary: [
			{ id: 1, name: "Vegetarian" },
			{ id: 3, name: "Gluten-Free" },
		],
		ingredients: [
			"Quinoa",
			"Cucumber",
			"Cherry tomatoes",
			"Red onion",
			"Kalamata olives",
			"Feta cheese",
			"Hummus",
			"Olive oil",
			"Lemon juice",
			"Fresh herbs",
		],
		instructions: [
			"Cook quinoa",
			"Chop vegetables",
			"Make dressing with oil and lemon",
			"Assemble bowls",
			"Top with feta and herbs",
			"Serve with hummus",
		],
		favorite: true,
	},
	{
		id: 8,
		title: "Homemade Guacamole",
		description:
			"Fresh and zesty guacamole dip, perfect for parties or snacking.",
		imageUrl:
			"https://downshiftology.com/wp-content/uploads/2019/04/Guacamole-1-2.jpg",
		prepTime: 15,
		cookTime: 0,
		servings: 6,
		difficulty: { id: 0, name: "Easy" },
		cuisineType: { id: 2, name: "Mexican" },
		mealType: { id: 4, name: "Snack" },
		dietary: [
			{ id: 1, name: "Vegetarian" },
			{ id: 2, name: "Vegan" },
			{ id: 3, name: "Gluten-Free" },
			{ id: 4, name: "Dairy-Free" },
		],
		ingredients: [
			"Ripe avocados",
			"Lime juice",
			"Red onion",
			"Tomato",
			"Jalapeño",
			"Cilantro",
			"Garlic",
			"Salt",
			"Cumin",
		],
		instructions: [
			"Mash avocados",
			"Add lime juice",
			"Mix in diced onion, tomato, and jalapeño",
			"Add minced garlic and cilantro",
			"Season with salt and cumin",
			"Serve with tortilla chips",
		],
		favorite: false,
	},
];
