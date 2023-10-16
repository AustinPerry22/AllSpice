<template>
{{ recipe }}
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup(){
    return { 
        recipe: computed(()=> AppState.activeRecipe)
     }
    }
};
</script>


<style lang="scss" scoped>

</style>