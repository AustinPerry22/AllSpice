<template>
    <section class="row justify-content-center text-center" id="cover">
      <div class="col-11-5 splash-img mt-4">
        <section class="row justify-content-end py-2">
          <div class="col-5 mt-2 mt-md-3">
            <SearchBar/>
          </div>
          <div class="col-1">
            <Login/>
          </div>
        </section>
        <h1 class="pt-3">All-Spice</h1>
        <h6>Cherish Your Family</h6>
        <h6 class="pb-5">And Their Cooking</h6>
      </div>
      <SelectCategory id="select-category"/>
    </section>
</template>

<script>
import Login from './Login.vue';
import SearchBar from './SearchBar.vue';
import SelectCategory from './SelectCategory.vue';

export default {
    setup() {
        return {};
    },
    components: { Login, SearchBar }
};
</script>


<style>
.splash-img{
  background-image: url('https://images.unsplash.com/photo-1597528662465-55ece5734101?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80');
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  border-radius: .5rem;
  filter: drop-shadow(.1rem 0.1rem .05rem rgba(0, 0, 0, 0.397))
}

h6, h1{
  color: rgb(240, 240, 240);
  filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}

.col-11-5{
  flex: 0 0 auto;
  width: 95.833333335%;
}

#cover{
  position: relative;
}
#select-category{
  position: absolute;
  bottom: -2vh;
}
</style>