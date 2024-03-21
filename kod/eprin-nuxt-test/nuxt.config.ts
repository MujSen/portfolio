// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: {
    enabled: true,

    timeline: {
      enabled: true,
    },
  },
  css: ['~/assets/css/global.css'],
  modules: ['@sidebase/nuxt-auth', '@pinia/nuxt', "@nuxtjs/tailwindcss"],
})