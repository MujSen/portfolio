import type { LayoutServerLoad } from './$types'

// Funkce pro načtení layoutu
export const load: LayoutServerLoad = async ({ locals }) => {
	// Validace uživatelského sezení
	const { session, user } = await locals.auth.validateUser()
	// Vrácení informace o uživateli (pokud je přihlášený)
	return { user }
}
