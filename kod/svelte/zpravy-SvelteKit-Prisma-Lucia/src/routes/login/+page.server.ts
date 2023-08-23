import { auth } from '$lib/server/lucia'
import { fail, redirect } from '@sveltejs/kit'
import type { Actions, PageServerLoad } from './$types'

// Načtení stránky
export const load: PageServerLoad = async ({ locals }) => {
	const session = await locals.auth.validate()
	if (session) {
		throw redirect(302, '/')
	}
}

// Akce při přihlašování
export const actions: Actions = {
	default: async ({ request, locals }) => {
		const { username, password } = Object.fromEntries(await request.formData()) as Record<
			string,
			string
		>

		try {
			// Použití klíče pro ověření uživatele
			const key = await auth.useKey('username', username, password)
			
			// Vytvoření relace pro přihlášeného uživatele
			const session = await auth.createSession(key.userId)
			locals.auth.setSession(session)
		} catch (err) {
			console.error(err)
			return fail(400, { message: 'Nemůžu přihlásit uživatele' })
		}
		
		// Přesměrování na hlavní stránku po přihlášení
		throw redirect(302, '/')
	}
}
