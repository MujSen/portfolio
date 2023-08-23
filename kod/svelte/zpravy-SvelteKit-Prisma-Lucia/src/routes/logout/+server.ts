import { auth } from '$lib/server/lucia'
import { redirect } from '@sveltejs/kit'
import type { RequestHandler } from './$types'

// Zpracování odhlášení
export const POST: RequestHandler = async ({ locals }) => {
	const session = await locals.auth.validate()
	if (!session) {
		throw redirect(302, '/')
	}

	// Zrušení platnosti relace (odhlášení uživatele)
	await auth.invalidateSession(session.sessionId)
	locals.auth.setSession(null)

	// Přesměrování na hlavní stránku po odhlášení
	throw redirect(302, '/')
}
