import type { PrismaClient } from '@prisma/client'

declare global {
	namespace App {
		// Rozhraní pro chyby {}
		interface Locals {
			auth: import('lucia-auth').AuthRequest
		}
		// Rozhraní pro data na stránce {}
		// Rozhraní pro platformu {}
	}
	var __prisma: PrismaClient

	/// <reference types="lucia-auth" />
	declare namespace Lucia {
		// Autentikační třída z luce-auth
		type Auth = import('$lib/server/lucia').Auth
		// Atributy uživatele
		type UserAttributes = {
			username: string
			name: string
		}
	}
}

export {}
