<template>
<section class="row">
    <div class="col-12 col-md-4 bg-img text-end">
    </div>
    <div class="col-12 col-md-8">
        <section class="row justify-content-between">
            <div class="col-6">
                <h4 class="category">{{ recipe.category }}</h4>
            </div>
            <div class="col-6">
                <div v-if="recipe.creatorId == accountId" class="text-end">
                    <button v-if="!locked" @click="toggleLock()" class="btn btn-info" ><i class="mdi mdi-lock"></i></button>
                    <button v-else @click="toggleLock()" class="btn btn-info"><i class="mdi mdi-lock-open-variant"></i></button>
                </div>
            </div>
        </section>
        <section class="row">
            <div class="col-12 col-md-6">
                <h5 class="text-center"><u>Instructions</u></h5>
                <div v-if="recipe.creatorId == accountId">
                    <div v-if="!locked">
                        <form @submit.prevent="editRecipe" class="text-center">
                            <textarea v-model="recipe.instructions" type="text" maxlength="5000" rows="15" class="form-control" required></textarea>
                            <button class="btn btn-success mt-1">Save Instructions</button>
                        </form>
                    </div>
                    <div v-else>
                        <p class="bg-dark-subtle">{{ recipe.instructions }}</p>
                    </div>
                </div>
            <div v-else>
            <p class="bg-dark-subtle">{{ recipe.instructions }}</p>
        </div>
    </div>
    <div class="col-12 col-md-6">
        <h5 class="text-center"><u>Ingredients</u></h5>
        <div v-for="ingredient in ingredients" :key="ingredient.id" class="d-flex bg-dark-subtle justify-content-between my-1">
            <h4 class="text-info">{{ ingredient.quantity }}  {{ ingredient.name }}</h4>
            <button v-if="!locked" @click="deleteIngredient(ingredient.id)" class="btn btn-danger"><i class="mdi mdi-delete"></i></button>
        </div>
        <div v-if="!locked">
            <form @submit.prevent="createIngredient">
                <label for="name">Ingredient Name:</label>
                <input v-model="ingredientData.name" type="text" required maxlength="255" class="form-control">
                <label for="quantity">Quantity:</label>
                <input v-model="ingredientData.quantity" type="text" maxlength="255" placeholder="1 Cup" class="form-control" required>
                <div class="text-center mt-md-2">
                    <button class="btn btn-success">Add Ingredient</button>
                </div>
            </form>
        </div>
    </div>
</section>
<div v-if="!locked" class="text-center text-md-end mt-5 mt-md-0">
    <button @click="deleteRecipe" class="btn btn-danger">Delete Recipe</button>
</div>
</div>  
</section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect, ref } from 'vue';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService';
import { recipesService } from '../services/RecipesService';
import { Modal } from 'bootstrap';
export default {
    setup(){
        const ingredientData = ref({})
        watchEffect(()=>{
            AppState.activeRecipe
            AppState.instructionsLock = true;
        })
        
    return { 
        ingredientData,
        locked: computed(()=> AppState.instructionsLock),
        recipe: computed(()=> AppState.activeRecipe),
        recipeImg: computed(()=> `url('${AppState.activeRecipe.img}')`),
        ingredients: computed(()=> AppState.ingredients),
        accountId: computed(()=> AppState.account.id),
        toggleLock(){
            AppState.instructionsLock = !AppState.instructionsLock;
        },

        async createIngredient(){
            try {
                await ingredientsService.createIngredient(ingredientData.value)
                ingredientData.value = {} 
            } catch (error) {
                Pop.error(error)
            }
        },

        async deleteIngredient(ingredientId){
            try{
                await ingredientsService.deleteIngredient(ingredientId)
            } catch (error){
                Pop.error(error)
            }
        },
        
        async editRecipe(){
            try{
                await recipesService.editRecipe(this.recipe)
                Pop.success("Instructions Saved")
            }catch (error){
                Pop.error(error)
            }
        },
        
        async deleteRecipe(){
            try {
                if(await Pop.confirm("Are you sure you want to delete this recipe?"))
                {
                    Modal.getOrCreateInstance("#active-recipe").hide()
                    await recipesService.deleteRecipe(this.recipe.id)
                    Pop.success("Recipe Deleted")
                }
            } catch (error) {
                Pop.error(error)
            }
        }


     }
    }
};
</script>


<style lang="scss" scoped>
.bg-img{
    background-image: v-bind(recipeImg);
    background-position: center;
    background-size: cover;
    height: 70vh;
    border-radius: .5rem;
    min-height: fit-content;
}
.category{
    color: #527360;
}

.instructions{
    background-color: rgba(128, 128, 128, 0.363);
}

@media screen and (max-width: 768px){
 .bg-img{
    height: 35vh;
    margin-bottom: 2vh;
 }
}
</style>