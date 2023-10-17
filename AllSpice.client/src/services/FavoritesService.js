import { AppState } from "../AppState";
import { Favorite } from "../models/Favorite";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class FavoritesService {
    async getFavorites()
    {
        const res = await api.get('/account/favorites')
        AppState.favorites = res.data.map(favorite => new Favorite(favorite));
    }

    async addFavorite(recipeId)
    {
        await api.post('api/favorites', {recipeId: recipeId})
        // TODO fix this, its ineffieceint 
        this.getFavorites()
    }

    async deleteFavorite(recipeId)
    {
        const favorite = AppState.favorites.find(fav=> fav.id == recipeId)
        await api.delete(`api/favorites/${favorite.favoriteId}`)
        // TODO same as above kinda
        const foundIndex = AppState.activeRecipes.find(recipe => recipe.favoriteId == favorite.favoriteId)
        if(foundIndex) AppState.activeRecipes.splice(foundIndex, 1)
        this.getFavorites()
    }

    setFavorites(){
        AppState.activeRecipes = AppState.favorites
    }
}

export const favoritesService = new FavoritesService();