// Importování závislostí
import { PrismaClient } from "@prisma/client"
import { env } from "$env/dynamic/private"

// Vytvoření instance klienta Prisma pro komunikaci s databází
const prisma = global.__prisma || new PrismaClient()

// Uložení instance klienta Prisma do globálního kontextu
if (env.NODE_ENV === "development") {
	global.__prisma = prisma
}

// Export instance klienta Prisma
export { prisma }
