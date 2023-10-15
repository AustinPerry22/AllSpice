import { AppState } from "../AppState";
import { Favorite } from "../models/Favorite";
import { api } from "./AxiosService";

class FavoritesService {
    async getFavorites()
    {
        const res = await api.get('/account/favorites')
        AppState.favorites = res.data.map(favorite => new Favorite(favorite));
        this.addFavoritesToRecipes()
    }

    addFavoritesToRecipes(){
        AppState.favorites.forEach(favorite =>{
            let recipe = AppState.recipes.find(recipe => recipe.id == favorite.recipeId)
            recipe.isFavorite = true
        })
    }
}

export const favoritesService = new FavoritesService();