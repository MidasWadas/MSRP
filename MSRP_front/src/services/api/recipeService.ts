import { IdName } from 'types/common';
import apiClient from './apiClient';

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

export interface CuisineOption {
  id: number;
  name: string;
  description: string;
}

export interface MealType {
  id: number;
  name: string;
}

export interface DietaryOption {
  id: number;
  name: string;
  description: string;
}

export interface DifficultyOptions {
  id: number;
  name: string;
}

export interface RecipeFilterParams {
  mealType?: number[];
  cuisineType?: number[];
  difficulty?: number[];
  dietary?: number[];
  searchQuery?: string;
  sortBy?: number;
  limit?: number;
  page?: number;
}

// Recipe API service

// Get all cuisine options
const recipeService = {
  getCuisineOptions: async () => {
    try {
      const response = await apiClient.get('/Recipes/GetCuisineOptions');
      return response.data as CuisineOption[];
    } catch (error) {
      console.error('Error fetching cuisine options:', error);
      throw error;
    }
  },

  // Get all meal type options
  getMealTypes: async () => {
    try {
      const response = await apiClient.get('/Recipes/GetMealTypes');
      return response.data as MealType[];
    } catch (error) {
      console.error('Error fetching meal types:', error);
      throw error;
    }
  },

  // Get all dietary options
  getDietaryOptions: async () => {
    try {
      const response = await apiClient.get('/Recipes/GetDietaryOptions');
      return response.data as DietaryOption[];
    } catch (error) {
      console.error('Error fetching dietary options:', error);
      throw error;
    }
  },

  // Get difficulty options
  getDifficultyOptions: async () => {
    try {
      const response = await apiClient.get('/Recipes/GetDifficultyOptions');
      return response.data as DifficultyOptions[];
    } catch (error) {
      console.error('Error fetching difficulty options:', error);
      throw error;
    }
  },

  // Get all recipes with optional filtering
  getRecipes: async (filters?: RecipeFilterParams) => {
    try {
      const response = await apiClient.get('/Recipes/GetRecipes', { params: filters });
      return response.data;
    } catch (error) {
      console.error('Error fetching recipes:', error);
      throw error;
    }
  },

  // Get a single recipe by ID
  getRecipeById: async (id: number) => {
    try {
      const response = await apiClient.get(`/Recipes/GetRecipe/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error fetching recipe with id ${id}:`, error);
      throw error;
    }
  },

  // Create a new recipe
  createRecipe: async (recipe: Omit<Recipe, 'id'>) => {
    try {
      const response = await apiClient.post('/Recipes/AddRecipe', recipe);
      return response.data;
    } catch (error) {
      console.error('Error creating recipe:', error);
      throw error;
    }
  },

  // Update an existing recipe
  updateRecipe: async (id: number, recipe: Partial<Recipe>) => {
    try {
      const response = await apiClient.put(`/Recipes/UpdateRecipe/${id}`, recipe);
      return response.data;
    } catch (error) {
      console.error(`Error updating recipe with id ${id}:`, error);
      throw error;
    }
  },

  // Delete a recipe
  deleteRecipe: async (id: number) => {
    try {
      const response = await apiClient.delete(`/Recipes/DeleteRecipe/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error deleting recipe with id ${id}:`, error);
      throw error;
    }
  },
};

export default recipeService;