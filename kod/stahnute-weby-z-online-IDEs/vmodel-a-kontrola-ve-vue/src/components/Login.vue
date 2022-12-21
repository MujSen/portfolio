<template>
  <div>
    <h2>Login</h2>
    <input v-model="uziv" type="text" placeholder="Napište uživatelské jméno" />
    <p v-if="jed == 1 || jed == 3">Není zadáno jméno</p>
    <input v-model="pass" type="password" placeholder="Napište heslo" />
    <p v-if="jed == 2 || jed == 3">Není zadáno heslo</p>
    <input @click="kliknutiTlacitka()" type="button" value="přihlásit" />
  </div>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      uziv: "",
      pass: "",
      jed: 0,
    };
  },
  methods: {
    kliknutiTlacitka() {
      this.verifikace();
    },
    verifikace() {
      //jen pomocí čísel :D uziv == 1 pass = 2 obe ==3
      if (this.uziv == "") {
        if (this.jed < 1 || this.jed === 2) {
          //pokud je menší než jedna nebo se rovná 2
          this.jed += 1; //Přidání
        }
      } else {
        if (this.jed == 3) {
          //odebrání odebere se když se rovná 3
          this.jed -= 1;
        } else if (this.jed == 1) {
          //dá nulu když se rovná 1
          this.jed = 0;
        }
      }

      if (this.pass == "") {
        if (this.jed < 2) {
          this.jed += 2;
        } //Přidání
      } else {
        if (this.jed == 3) {
          //odebrání odebere se když se rovná 3
          this.jed -= 2;
        } else if (this.jed == 2) {
          //dá nulu když se rovná 2
          this.jed = 0;
        }
      }
      if (this.jed == 0) {
        this.odeslatNaApi(this.uziv, this.pass);
      }
    },
    odeslatNaApi( uz, pas) {
      console.log(uz + pas)
      /* -- Jak by se potvrdili údaje s api
fetch('http://urlecho.appspot.com/echo?status=200&Content-Type=text%2Fhtml&body=session-id%3A%20598A', {
    method: 'POST', //Post postuje na server Get dostává ze serveru
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    },
    body: JSON.stringify({ "uzivatel":uz,"heslo":pas})
})
.then(response => response.json())
.then(response => console.log(JSON.stringify(response)))*/
    let vysledek = {"session-id":"55AD"};
    /*Uložilo by se do cache nebo localstorage*/
    
    },
  },
};
</script>

<style>
</style>