<template>
  <section>
    <h1>Profil</h1>
      <h2>Zde se můžete přihlásit/zaregistrovat</h2>
      <div v-if="nereg && nepri">
        <label v-if="!reg">Zadejte email/jmeno</label>
        <label v-if="reg">Zadejte email</label>
        <input type="text" v-model="email">
        <label class="alert" v-if="reg && error.includes('E')">Email již existuje</label>
        <label class="alert"  v-if="reg && error.includes('M')">Email není platný</label>
        <label class="alert"  v-if="!reg && error.includes('E')">Není zadán email nebo jméno</label>

        <label>Zadejte heslo</label>
        <input type="text" v-model="heslo">
        <label class="alert"  v-if="reg && error.includes('P')">Heslo není dostatečně silné</label>
        <label class="alert"  v-if="!reg && error.includes('H')">Není zadáno heslo</label>
        <label class="alert"  v-if="!reg && error.includes('P')">Přihlášení se nezdařilo zkuste zkontrolovat svoje údaje.</label>
        <button v-if="!reg" v-on:click="reg=true">Nejste zaregistrováni?</button>
        <label v-if="reg">Zadejte uživatelské jméno</label>
        <input type="text" v-if="reg" v-model="jmeno">
        <label class="alert"  v-if="reg && error.includes('J')">Jméno již existuje</label>
        <label class="alert"  v-if="reg && error.includes('N')">Jméno musí být alespoň 3 znaky dlouhé</label>
        <button v-on:click="prihlasit" v-if="!reg">Přihlásit</button>
        <button v-on:click="zaregistrovat" v-if="reg">Zaregistrovat</button>
      </div>
      <div v-if="!nereg">
        <h2>Byl jste zaregistrován!</h2>
      </div>
      <div v-if="!nepri">
        <h2>Jste prihlášen!</h2>
      </div>
  </section>
</template>

<script>
import { useProfilStore } from '@/stores/profil.js'

export default {
  setup() {
    const profil =  useProfilStore()
    return {
      profil
    }
  },
  data(){
    return{
      reg: false,
      email: '',
      heslo: '',
      jmeno: '',
      error: '',
      nereg: true,
      nepri: true

    }
  },
  methods: {
    zaregistrovat(){
      this.error = this.profil.pridatUzivatele(this.email, this.jmeno, this.heslo);
      if(this.error==''){
        this.nereg = false;
      }
    },
    prihlasit(){
      this.error = this.profil.prihlasitUzivatele(this.email,this.heslo);
      if(this.error==''){
        this.nepri = false;
      }
    }
  }
}
</script>

<style scoped>
section div{
  display: flex;
  flex-flow: column;
  width: fit-content;
}
input{
    width: fit-content;
  }
  .alert{
    color: red;
  }
</style>