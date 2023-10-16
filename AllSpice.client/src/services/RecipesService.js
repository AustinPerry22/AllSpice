import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { api } from "./AxiosService"

class RecipesService{

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        const newRecipe = new Recipe(res.data)
        AppState.recipes.push(newRecipe)
        AppState.activeRecipe = newRecipe
    }
    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(recipe => new Recipe(recipe))
        AppState.activeRecipes = AppState.recipes
    }

    async editRecipe(recipe){
        await api.put(`api/recipes/${recipe.id}`, recipe)
    }

    setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(recipe => recipe.id == recipeId)
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