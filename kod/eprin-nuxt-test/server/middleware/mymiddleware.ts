import type { Session } from "next-auth";
import type { JWT } from "next-auth/jwt";

import { getServerSession, getToken } from "#auth";

declare module "h3" {
  interface H3EventContext {
    authSession: Session | null;
    authToken: JWT | null;
  }
}
export default defineEventHandler(async (event) => {
  const session = await getServerSession(event);
  event.context.authSession = session;

  const token = await getToken({ event: event });
  event.context.authToken = token;
});