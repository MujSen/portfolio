import type { Actions, PageServerLoad } from './$types';
import { prisma } from '$lib/server/prisma';
import { error, fail, redirect } from '@sveltejs/kit';

// Načtení dat na stránku
export const load: PageServerLoad = async () => {
    return {
        articles: await prisma.article.findMany(),
    };
};

// Akce pro vytvoření článku
export const actions: Actions = {
    createArticle: async ({ request, locals }) => {
        const { session } = await locals.auth.validateUser();
        if (!session) {
            throw redirect(302, '/');
        }

        const { title, content } = Object.fromEntries(await request.formData()) as Record<
            string,
            string
        >;

        const now = new Date();
        const lastUpdateString = now.toISOString();

        try {
            await prisma.article.create({
                data: {
                    title,
                    content,
                    last_update: lastUpdateString,
                    userId: session.userId,
                },
            });
        } catch (err) {
            console.error(err);
            return fail(500, { message: 'Nepodařilo se vytvořit článek.' });
        }

        return {
            status: 201,
        };
    },

    // Akce pro smazání článku
    deleteArticle: async ({ url, locals }) => {
        const session = await locals.auth.validate();
        if (!session) {
            throw redirect(302, '/');
        }
        const id = url.searchParams.get('id');
        if (!id) {
            return fail(400, { message: 'Neplatný požadavek' });
        }

        try {
            const article = await prisma.article.findUnique({
                where: {
                    id: Number(id),
                },
            });

            if (!article) {
                return fail(404, { message: 'Článek nebyl nalezen' });
            }

            if (article.userId !== session.userId) {
                throw error(403, 'Neautorizováno');
            }

            await prisma.article.delete({
                where: {
                    id: Number(id),
                },
            });
        } catch (err) {
            console.error(err);
            return fail(500, {
                message: 'Něco se pokazilo při mazání článku',
            });
        }

        return {
            status: 200,
        };
    },

    // Akce pro aktualizaci článku
    updateArticle: async ({ request, url, locals }) => {
        const session = await locals.auth.validate();
        if (!session) {
            throw redirect(302, '/');
        }

        const { id } = Object.fromEntries(url.searchParams) as Record<string, string>;

        const now = new Date();
        const lastUpdateString = now.toISOString();

        try {
            const article = await prisma.article.findUnique({
                where: {
                    id: Number(id),
                },
            });

            if (!article) {
                return fail(404, { message: 'Článek nebyl nalezen' });
            }

            if (article.userId !== session.userId) {
                throw error(403, 'Neautorizováno');
            }

            await prisma.article.update({
                where: {
                    id: Number(id),
                },
                data: {
                    last_update: lastUpdateString,
                },
            });
        } catch (err) {
            console.error(err);
            return fail(500, {
                message: 'Něco se pokazilo při aktualizaci článku',
            });
        }

        return {
            status: 200,
        };
    },
};
