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
  cuisine: IdName;
  mealType: IdName;
  dietaries: IdName[];
  ingredients: string[];
  instructions: string[];
  createdByUserId: number;
}

export interface RecipesListState {
  loading: boolean;
  error: boolean;
  recipes: Recipe[];
}