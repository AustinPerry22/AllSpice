<template>
    <section class="row justify-content-center text-center">
      <div class="col-11-5 splash-img mt-4">
        <section class="row justify-content-end py-2">
          <div class="col-5">
            searchbar
          </div>
          <div class="col-1">
            <Login/>
          </div>
        </section>
        <h1 class="pt-5">All-Spice</h1>
        <h6>Cherish Your Family</h6>
        <h6 class="pb-5">And Their Cooking</h6>
      </div>
    </section>
</template>

<script>
import Login from './Login.vue';

export default {
    setup() {
        return {};
    },
    components: { Login }
};
</script>


<style>
.splash-img{
  background-image: url('https://images.unsplash.com/photo-1597528662465-55ece5734101?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80');
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  
}

.col-11-5{
  flex: 0 0 auto;
  width: 95.833333335%;
}
</style>