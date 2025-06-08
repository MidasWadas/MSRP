import { call, put, takeLatest } from 'redux-saga/effects';
import axios, { type AxiosResponse } from 'axios';
import {
  fetchRecipesStart,
  fetchRecipesSuccess,
  fetchRecipesFailure,
} from './recipes-list-slice';
import { type Recipe } from './types';

function fetchRecipesApi(): Promise<AxiosResponse<{ recipes: Recipe[] }>> {
  const baseUrl = process.env.REACT_APP_API_BASE_URL || 'https://localhost:44373';
  return axios.get(`${baseUrl}/api/recipes/get-all`);
}

function* fetchRecipesWorker() {
  try {
    const response: AxiosResponse<{ recipes: Recipe[] }> = yield call(fetchRecipesApi);
    yield put(fetchRecipesSuccess(response.data.recipes));
  } catch (error) {
    yield put(fetchRecipesFailure());
  }
}

export function* watchFetchRecipes() {
  yield takeLatest(fetchRecipesStart.type, fetchRecipesWorker);
}
