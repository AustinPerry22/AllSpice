import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { api } from "./AxiosService"

class RecipesService{
    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(recipe => new Recipe(recipe))
        AppState.activeRecipes = AppState.recipes
    }

    changeRecipes(recipeType){
        let activeRecipes = AppState.activeRecipes
        const allRecipes = AppState.recipes
        if(recipeType == "home")
        {
            activeRecipes = allRecipes
        }
        if(recipeType == "favorite")
        {
            activeRecipes = allRecipes.filter(recipe => recipe.isFavorite == true)
        }
        if(recipeType == "mine")
        {
            activeRecipes = allRecipes.filter(recipe => recipe.creatorId == AppState.account.id)
        }
        AppState.activeRecipes = activeRecipes
    }
}
export const recipesService = new RecipesService()