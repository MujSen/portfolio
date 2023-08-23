// Importujeme nezbytné moduly
// import { handleHooks } from "@lucia-auth/sveltekit"
import { auth } from '$lib/server/lucia'
import type { Handle } from '@sveltejs/kit'
// import { sequence } from "@sveltejs/kit/hooks"

// Definujeme funkci "handle", která zpracovává požadavky
export const handle: Handle = async ({ event, resolve }) => {
	// Přidáme autentikační instanci do kontextu události (event.locals)
	event.locals.auth = auth.handleRequest(event)
	// Vyřešíme požadavek pomocí funkce resolve
	return await resolve(event)
}
