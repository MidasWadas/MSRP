import { createSlice, type PayloadAction } from '@reduxjs/toolkit';
import type { Recipe, RecipesListState } from './types';

const initialState: RecipesListState = {
  loading: false,
  error: false,
  recipes: [],
};

const recipesListSlice = createSlice({
  name: 'recipesList',
  initialState,
  reducers: {
    fetchRecipesStart(state) {
      state.loading = true;
      state.error = false;
    },
    fetchRecipesSuccess(state, action: PayloadAction<Recipe[]>) {
      state.loading = false;
      state.recipes = action.payload;
    },
    fetchRecipesFailure(state) {
      state.loading = false;
      state.error = true;
    },
  },
});

export const {
  fetchRecipesStart,
  fetchRecipesSuccess,
  fetchRecipesFailure,
} = recipesListSlice.actions;

export default recipesListSlice.reducer;
