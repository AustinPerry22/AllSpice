import { AppState } from "../AppState";
import { Favorite } from "../models/Favorite";
import { api } from "./AxiosService";

class FavoritesService {
    async getFavorites()
    {
        const res = await api.get('/account/favorites')
        AppState.favorites = res.data.map(favorite => new Favorite(favorite));
    }
}

export const favoritesService = new FavoritesService();