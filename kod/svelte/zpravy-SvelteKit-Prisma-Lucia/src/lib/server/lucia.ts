// Importy
// import { sveltekit } from 'lucia-auth/middleware'
import lucia from 'lucia-auth'
import prismaAdapter from '@lucia-auth/adapter-prisma'
import { sveltekit } from 'lucia-auth/middleware'
import { dev } from '$app/environment'
import { prisma } from '$lib/server/prisma'

// Vytvoření instance autentikačního modulu
export const auth = lucia({
  // Použití adaptéru pro Prisma
  adapter: prismaAdapter(prisma),

  // Nastavení prostředí na základě režimu vývoje nebo produkce
  env: dev ? 'DEV' : 'PROD',

  // Použití middleware pro SvelteKit
  middleware: sveltekit(),

  // Transformace dat uživatele z databáze
  transformDatabaseUser: (userData) => {
    return {
      userId: userData.id,
      username: userData.username,
      name: userData.name
    }
  }
})

// Typ pro autentikační modul
export type Auth = typeof auth
