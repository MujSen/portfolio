import { auth } from '$lib/server/lucia'
import { fail, redirect } from '@sveltejs/kit'
import type { Actions, PageServerLoad } from './$types'

// Funkce pro načtení stránky registrace
export const load: PageServerLoad = async ({ locals }) => {
	const session = await locals.auth.validate()
	if (session) {
		throw redirect(302, '/')
	}
}

export const actions: Actions = {
	default: async ({ request }) => {
		const { name, username, password } = Object.fromEntries(await request.formData()) as Record<
			string,
			string
		>
		try {
			// Vytvoření nového uživatele
			await auth.createUser({
				primaryKey: {
					providerId: 'username',
					providerUserId: username,
					password
				},
				attributes: {
					name,
					username
				}
			})
		} catch (err) {
			console.error(err)
			return fail(400, { message: 'Nemůžu zaregistrovat uživatele' })
		}
		// Přesměrování na stránku přihlášení po úspěšné registraci
		throw redirect(302, '/login')
	}
}
