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

    setFavorites(){
        AppState.activeRecipes = AppState.favorites
    }
}

export const favoritesService = new FavoritesService();