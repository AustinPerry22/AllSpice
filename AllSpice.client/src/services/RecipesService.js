import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { api } from "./AxiosService"

class RecipesService{
    async GetAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(recipe => new Recipe(recipe))
    }
}
export const recipesService = new RecipesService()