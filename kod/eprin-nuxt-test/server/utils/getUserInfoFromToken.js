import { getToken } from '#auth'

export async function getUserInfoFromToken(event){
    const token = await getToken({ event })
    if (!token || !token.userInfo) return false
    return token.userInfo
}