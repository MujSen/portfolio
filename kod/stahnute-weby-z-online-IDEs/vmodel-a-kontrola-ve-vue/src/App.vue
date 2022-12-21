<template>
  <div>
    <img alt="Vue logo" src="./assets/logo.png" />
    <Login />
    <table>
      <th>Jmena</th>
      <th>Hesla</th>
      <th>IPs</th>
      <th>Oblibené věci</th>
      <tr v-for="item in data" v-bind:key="item">
        <td v-for="i in item" v-bind:key="i">
          {{ i }}
        </td>
      </tr>
    </table>
    <p>Přidej se do listu</p>
    <input v-model="jmeno" type="text" placeholder="Zadej jmeno" />
    <input v-model="heslo" type="text" placeholder="Zadej heslo" />
    <input v-model="ipina" type="text" placeholder="Zadej ip" />
    <input v-model="obliben" type="text" placeholder="Zadej oblíbenou věc" />
    <input type="button" value="Přidej" @click="pridej()" />
  </div>
</template>

<script>
import LoginVue from "./components/Login.vue";

export default {
  name: "App",
  components: {
    Login: LoginVue,
  },
  data() {
    return {
      jmeno: "",
      heslo: "",
      ipina: "",
      obliben: "",
      data: [
        { jm: "A", he: "123", ip: "108.10.0.5", ob: "kočka" },
        { jm: "da", he: "455", ip: "220.10.5.11", ob: "pes" },
        { jm: "ha", he: "554489", ip: "10.10.5.11", ob: "kočka" },
      ],
    };
  },
  methods: {
    pridej() {
      this.data.push({
        jm: this.jmeno,
        he: this.heslo,
        ip: this.ipina,
        ob: this.obliben,
      });
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
