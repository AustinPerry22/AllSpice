import { reactive } from 'vue'
import { Recipe } from './models/Recipe.js'
import { Ingredient } from './models/Ingredient.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  favorites: [],

  /**@type {Recipe[]} */
  recipes: [],

  /**@type {Recipe[]} */
  activeRecipes: [],

  /**@type {Recipe} */
  activeRecipe: {},
  
  /**@type {Ingredient[]} */
  ingredients: [],

  instructionsLock: true
})
