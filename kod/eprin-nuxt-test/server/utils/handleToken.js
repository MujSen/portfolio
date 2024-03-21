import { getToken } from '#auth'

export async function handleToken(event){
    const token = await getToken({ event })
    if (!token || !token.accessToken) return false
    return token.accessToken
}