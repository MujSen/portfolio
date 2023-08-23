import type { Actions, PageServerLoad } from './$types'
import { prisma } from '$lib/server/prisma'
import { error, fail } from '@sveltejs/kit'

// Funkce pro načtení dat při načtení stránky
export const load: PageServerLoad = async ({ params, locals }) => {
	const { session, user } = await locals.auth.validateUser()
	if (!session || !user) {
		throw error(401, 'Neautorizovaný uživatel')
	}

	const getArticle = async (userId: string) => {
		const article = await prisma.article.findUnique({
			where: {
				id: Number(params.articleId)
			}
		})
		if (!article) {
			throw error(404, 'Zprávu se nepodařilo najít')
		}
		if (article.userId !== user.userId) {
			throw error(403, 'Neautorizovaný uživatel')
		}

		return article
	}

	return {
		article: getArticle(user.userId)
	}
}

// Definice akcí pro editaci zprávy
export const actions: Actions = {
	updateArticle: async ({ request, params, locals }) => {
		const { session, user } = await locals.auth.validateUser()
		if (!session || !user) {
			throw error(401, 'Neautorizovaný uživatel')
		}

		const { title, content } = Object.fromEntries(await request.formData()) as Record<
			string,
			string
		>

		try {
			const article = await prisma.article.findUniqueOrThrow({
				where: {
					id: Number(params.articleId)
				}
			})

			if (article.userId !== user.userId) {
				throw error(403, 'Nemůže editovat tuhle zprávu')
			}
			await prisma.article.update({
				where: {
					id: Number(params.articleId)
				},
				data: {
					title,
					content
				}
			})
		} catch (err) {
			console.error(err)
			return fail(500, { message: 'Nešlo změnit zprávu' })
		}

		return {
			status: 200
		}
	}
}
