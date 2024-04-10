import { NuxtAuthHandler } from '#auth'

export default NuxtAuthHandler({
  secret: process.env.AUTH_SECRET,
  providers: [
    {
      id: 'openid-connect',
      name: 'OpenID Connect',
      type: 'oauth',
      wellKnown: process.env.WELL_KNOWN_URL,
      authorization: {
        params: { scope: "openid profile api_tablet" }, 
      },
      //userinfo: process.env.USER_INFO_URL,
      userinfo: {
        url: process.env.USER_INFO_URL,
        async request(context) {
          const response = await fetch(process.env.USER_INFO_URL, {
            headers: {
              Authorization: `Bearer ${context.tokens.access_token}`,
            },
          });
          const res = await response.json();
          return res;
        },
      },
      clientId: process.env.CLIENT_ID,
      idToken: true,
      clientSecret: process.env.CLIENT_SECRET,
      checks: ['pkce', 'state'],
      async profile(profile, token) {
        return profile /*{
          id:  profile.id,
          exp: profile.exp,
          iss: profile.iss,
          aud: profile.aud,
          iat: profile.iat,
          at_hash: profile.at_hash,
          s_hash: profile.s_hash,
          sid: profile.sid,
          sub: profile.sub,
          auth_time: profile.auth_time,
          idp: profile.idp,
          amr: profile.amr,
        }*/
      },
    }
  ],
  session: {
    strategy: 'jwt', // <-- make sure to use jwt here
    maxAge: 30 * 24 * 60 * 60
  },
  callbacks: {
    jwt: async ({ token, account, user }) => {
      //console.log("JWTacc", user) YEP
      //console.log("JWTacc", account) NOPE
      if (account && account.access_token) {
        token.accessToken = account.access_token; 
        token.userInfo = user;
      }
      return token;
    },
  },
})
