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

    async deleteRecipe(recipeId){
        await api.delete(`api/recipes/${recipeId}`)
        AppState.activeRecipe = {}
        const allfoundIndex = AppState.recipes.findIndex(recipe => recipe.id == recipeId)
        AppState.recipes.splice(allfoundIndex, 1)

        const favoriteIndex = AppState.favorites.findIndex(recipe => recipe.id == recipeId)
        AppState.favorites.splice(favoriteIndex, 1)
        const activefoundIndex = AppState.activeRecipes.findIndex(recipe => recipe.id == recipeId)
        AppState.activeRecipes.splice(activefoundIndex, 1)
    }

    setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(recipe => recipe.id == recipeId)
    }

    changeRecipes(recipeType){
        let activeRecipes = AppState.activeRecipes
        const allRecipes = AppState.recipes
        AppState.activeRecipes = []
        if(recipeType == "home")
        {
            activeRecipes = allRecipes
        }
        if(recipeType == "mine")
        {
            activeRecipes = allRecipes.filter(recipe => recipe.creatorId == AppState.account.id)
        }
        AppState.activeRecipes = activeRecipes
    }

    searchRecipes(searchData){
        let nameFiltered = AppState.recipes.filter(recipe => recipe.title.toLowerCase() == searchData.search.toLowerCase())
        let categoryFiltered = AppState.activeRecipes = AppState.recipes.filter(recipe => recipe.category.toLowerCase() == searchData.search.toLowerCase())
        let activeRecipes = [...nameFiltered, ...categoryFiltered]
        AppState.activeRecipes=activeRecipes
    }
}
export const recipesService = new RecipesService()