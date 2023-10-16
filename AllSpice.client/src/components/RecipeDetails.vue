<template>
{{ recipe }}
<div v-if="!locked">
    form here
    <button @click="toggleLock()" class="btn btn-secondary">lock</button>
</div>
<div v-else>
    Steps <button @click="toggleLock()" class="btn btn-secondary">unlock</button>
</div>
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
        toggleLock(){
            AppState.instructionsLock = !AppState.instructionsLock;
        }
     }
    }
};
</script>


<style lang="scss" scoped>

</style>