<template>
<section class="row">
    <div class="col-4 bg-img text-end">
        <button class="btn btn-light"><i class="mdi mdi-heart"></i></button>
    </div>
    <div class="col-4">
        <h5>{{ recipe.category }}</h5>
        <p>{{ recipe.instructions }}</p>
        <div v-if="recipe.creatorId == accountId">
            <div v-if="!locked">
                form here
                <button @click="toggleLock()" class="btn btn-secondary">lock</button>
            </div>
            <div v-else>
                Steps <button @click="toggleLock()" class="btn btn-secondary">unlock</button>
            </div>
        </div>
    </div>
    <div class="col-4">
        ingredients
    </div>
</section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
export default {
    setup(){
        watchEffect(()=>{
            AppState.activeRecipe
            AppState.instructionsLock = true;
        })
    return { 
        locked: computed(()=> AppState.instructionsLock),
        recipe: computed(()=> AppState.activeRecipe),
        recipeImg: computed(()=> `url('${AppState.activeRecipe.img}')`),
        accountId: computed(()=> AppState.account.id),
        toggleLock(){
            AppState.instructionsLock = !AppState.instructionsLock;
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
</style>