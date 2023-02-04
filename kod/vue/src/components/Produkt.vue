<template>
  <div>
    <img v-bind:src="img" v-bind:alt="txt" />
    <p>{{ txt }}</p>
    <button v-on:click="clicknul" v-if="clicked == false">Přidat do košíku</button>
    <div v-if="clicked == true">
      <button v-on:click="uber">-</button>
      <p>{{ pocet }}</p>
      <button v-on:click="pridej">+</button>
    </div>
    <p v-if="pocet == 0">{{ cena }} Kč</p>
    <p v-if="pocet!==0">{{ cenaZPole() }} Kč</p>
  </div>
</template>
<style scoped>
div {
  text-align: center;
  width: fit-content;
}
div > div {
  display: flex;
  justify-content: space-around;
  width: 100%;
  margin-top: 5px;
}

img {
  max-width: 150px;
  max-height: 100px;
}

button {
  background-color: rgb(255, 251, 251);
  border: none;
}
</style>

<script>
import { usePolozkyStore } from '@/stores/kosik.js'



export default {

    props: ['txt', 'img','id','cena','pocee'],
    mounted() {
      if(this.id!=undefined && this.store.existujeVPoli(this.id)){
        let element = this.store.vratZPole(this.id);
        if(element!=undefined){
          this.clicked=true;
          this.pocet=element.pocet;
        }
      }
    },
    setup(){
        const store = usePolozkyStore()
        
        return {
            store,
        }
    },
    data() {
    return {
      clicked: false,
      pocet: 0,
      store: usePolozkyStore,
      cena: this.cena
    }
  },
  methods: {
    clicknul() { //Když se klikne na polozku vzdy +
        if (this.clicked==true) { //Přidá
            this.pocet++;
            this.manipulacePolozek();
        }
        else{ //Inicializuje
            this.pocet=1;
            this.clicked=true;
            this.manipulacePolozek();
        }
    },
    uber(){ //- tlac
        
        if(this.pocet<1){
            this.clicked=false;
        }
        else{
          this.pocet--;
        }
        this.manipulacePolozek();
    },
    pridej(){ //+ tlac
        this.pocet++;
        this.manipulacePolozek();
    },
    manipulacePolozek(){
        let item = {txt: this.txt, img: this.img, id: this.id, cena: this.cena, pocet: this.pocet};
        this.store.pridejDoPole(item);
    },
    cena(){
      let cen=0;
      if(this.pocet == 0){
        cen= this.cena;
      }
      else{
        cen= this.cena*this.pocet;
      }
      return cen;
    },
    cenaZPole(){
      console.log(this.store.vratCenu(this.id));
      return this.store.vratCenu(this.id);
    },
  }
};
</script>