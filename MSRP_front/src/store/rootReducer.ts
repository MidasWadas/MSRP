import { combineReducers } from '@reduxjs/toolkit';
import recipesListReducer from 'features/recipes/recipes-list/recipes-list-slice';

const rootReducer = combineReducers({
  recipesList: recipesListReducer,
  // tu dodasz kolejne reducery jak np. recipeDetails, filters, itd.
});

export type RootState = ReturnType<typeof rootReducer>;

export default rootReducer;
