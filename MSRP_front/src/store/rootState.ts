import { combineReducers } from '@reduxjs/toolkit';
import recipesListReducer from 'features/recipes/recipes-list/recipes-list-slice';

export const rootReducer = combineReducers({
  recipesList: recipesListReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
