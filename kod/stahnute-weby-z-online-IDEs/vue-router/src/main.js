// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import Router from "vue-router";

import App from "./App";
import Home from "./views/Home";
import About from "./views/About";
import Todos from "./views/Todos";
import Zprava from "./views/Zprava";
import Obliben from "./views/Obliben";

Vue.use(Router);

const routes = [
  { path: "/", component: Home },
  { path: "/about", component: About },
  { path: "/todos", component: Todos },
  { path: "/zprava", component: Zprava },
  { path: "/obliben", component: Obliben },
];

const router = new Router({
  routes
});

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
