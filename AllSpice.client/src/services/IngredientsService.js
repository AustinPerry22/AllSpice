import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { api } from "./AxiosService"

class IngredientsService {

    async createIngredient(ingredient)
    {
        ingredient.recipeId = AppState.activeRecipe.id
        const res = await api.post(`api/ingredients`, ingredient)
        AppState.ingredients.push(new Ingredient(res.data))
    }
    async getIngredients()
    {
        const res = await api.get(`api/recipes/${AppState.activeRecipe.id}/ingredients`)
        AppState.ingredients = res.data.map(ingredient => new Ingredient(ingredient))
    }
}
export const ingredientsService = new IngredientsService()