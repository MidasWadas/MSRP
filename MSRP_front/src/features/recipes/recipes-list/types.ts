import { type IdName } from 'types/common';

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

export interface RecipesListState {
  loading: boolean;
  error: boolean;
  recipes: Recipe[];
}