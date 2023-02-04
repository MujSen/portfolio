<template>
  <section>
    <div v-if="!objednavka">
    <h1>Košík</h1>
    <ul>
        <li v-for="product in store.polozky" :key="product.id">
            <Produkt :txt="product.txt" :img="product.img" :cena="product.cena" :id="product.id"/>
            <p v-on:click="odstranZKosiku(product)">Ostranit z košíku</p>
        </li>
    </ul>
    <div v-if="store.polozky.length>0">
      <p>Celková cena je {{ store.cenaZaVse }} Kč</p>
      <p>Nabízíme taky převod na jinou měnu, používáme aktualní kurz čnb</p>
      <button v-on:click="prepocitat">Chci přepočítat!</button>
      <p v-if="zjisti==false">Zjišťuji kurz</p>
      <div v-if="clc">
      <select v-model="select">
        <option v-for="item in pole" v-bind:key="item[1]">{{item[1]}}</option>
      </select>
      <p v-if="select">Přepočtená cena na {{ prevest(select) }} {{ select }}</p>
      </div>
      <button v-on:click="objednavka=true" >Dokončit objednávku</button>
    </div>
    <p v-else>Přidejte něco</p>
  </div>
  <div v-if="objednavka" >
    <h1>Pojďme vyplnit pár záknladních informací</h1>
    <form action="POST">
      <label>Zadejte Email</label>
      <input type="text">
      <label>Zadejte jméno a příjmení</label>
      <input type="text">
      <label>Zadejte aresu bydliště</label>
      <input type="text">
      <input type="submit" value="Pokračovat...">
    </form>
  </div>
  </section>
</template>

<script>
import { usePolozkyStore } from '@/stores/kosik.js'
import Produkt from '../components/Produkt.vue'
import { useProfilStore } from '@/stores/profil.js'

export default {
  setup() {
    const store = usePolozkyStore()
    const profil =  useProfilStore()
    return {
      store,
      profil
    }
  },
  data(){
      return{
        pole: [],
        select: 0,
        clc: false,
        zjisti: true,
        objednavka: false
      }
    },
  components: {
    Produkt
  },
  methods: {
    odstranZKosiku(el){
        el.pocet=0;
        this.store.pridejDoPole(el);
    },
    prepocitat(){
      this.zjisti = false;
      fetch('https://cors-anywhere.herokuapp.com/https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt')
      .then(response => response.text())
      .then(text => {
        text = text.replaceAll(',','.');
        const lines = text.split('\n');
        const filteredLines = lines.slice(2);
        const result = filteredLines.map(line => line.split('|').slice(-3));
        this.pole = result;
        this.clc = true;
        this.zjisti = true;
        console.log(this.clc);
      })
    },
    prevest(mod){
      let ret = 0;
      this.pole.forEach((el)=>{
        if (el[1]==mod) {
          ret = Math.round((this.store.cenaZaVse/el[2])*el[0]);
          
        }
      })
      return ret
    },
  },
}
</script>

<style scoped>
    form{
        display: flex;
        flex-flow: column;
        width: fit-content; 
    }
    form input{
      width: fit-content; 
    }
    li{
        position: relative;
        display: flex;
        align-items: center;
        padding: 20px;
        background-color: rgb(51, 51, 51);
    }
    li p{
        color: aliceblue;
        margin-left: 20px;
    }
    li:nth-child(odd){
        background-color: rgb(19, 19, 19);
    }
</style>