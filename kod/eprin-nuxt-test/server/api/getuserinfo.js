import { getUserInfoFromToken } from "../utils/getUserInfoFromToken";

export default defineEventHandler(async (event) => {
  const token = await handleToken(event);
  if (token == false) {
    console.log("FALSE");
    return error("Nemáš přístupový token zkus se odhlásit a přihlásit!");
  }
  try {
    const response = await fetch(
      "https://api-ts-tablet-test.jrkdigital.eu/v1/user/user-info",
      {
        method: "GET",
        headers: {
          accept: "application/json",
          Authorization:
            //"Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjhEMDU2QjI0NEY2MjYzOEQ4OURDRTAxNjg2MTlFRDg5QUU3RjExNDZSUzI1NiIsInR5cCI6ImF0K2p3dCIsIng1dCI6ImpRVnJKRTlpWTQySjNPQVdoaG50aWE1X0VVWSJ9.eyJuYmYiOjE3MTA5MzYzOTgsImV4cCI6MTcxMDkzOTk5OCwiaXNzIjoiaHR0cHM6Ly9hdXRoLnRlc3QuZWNvbml0LmNoeXRyZW9kcGFkeS5jeiIsImF1ZCI6ImFwaV90YWJsZXQiLCJjbGllbnRfaWQiOiJ0c190ZXN0Iiwic3ViIjoiMzU1MjciLCJhdXRoX3RpbWUiOjE3MTA5MzYzOTgsImlkcCI6IkFNIiwibmFtZSI6Ik5vdsOhaywgIEphbiIsImVtYWlsIjoiam5vdmFrQGVwcmluLmN6Iiwicm9sZSI6IsWZaWRpxI0gVFMiLCJqdGkiOiIyNTQzOUExMDQ2RTVCNDkxRTdGMkU0NEZDQTg3Njk2NiIsInNpZCI6IkI1NDI4NThFMDRGNDBGMDM3RDQzRjNDNUQxNzY4OTRCIiwiaWF0IjoxNzEwOTM2Mzk4LCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwiYXBpX3RhYmxldCJdLCJhbXIiOlsiZXh0ZXJuYWwiXX0.mng__D3g2g-dXyftmhvYmkFNxKGgBbcxeH8N7SsOn36h2lVlqo_7QSq7aoU0Ln1HtwHGlYZhwvnXC5TY_WS2PUYetT1_E7jOU6DludxzmXuSkM8tIgnaiF6Mf3BQtsEMSgjzsWUW7sU1rY42Skli1sxvPU3stM77boKNXGLntWF-FkLt4ii_eQ1b_pCXU09he3lwBU9qPL1U-ih3vPNcaRyEj_lIK12OWTL6rOFMwlSJYsVO2A1WXlww-Jf_sXEO-ugO4DxN326ja7Pzv1mvugEoxM2Q-Dqxu9bDbuQ0hwWexpoq7_fR4GdGue_LOpqI8nIoOX54-7AmBR_qh-39sg",
            "Bearer " + token,
        },
      }
    );

    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    const data = await response.json();
    return { data };
  } catch (error) {
    //console.error("There was a problem with your fetch operation:", error);
    return { error };
  }
});
