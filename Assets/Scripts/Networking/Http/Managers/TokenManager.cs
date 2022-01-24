// created by yasintuncel
using BattleTacticsOnline.Managers;
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BattleTacticsOnline.Networking.Http.Managers
{
    public class TokenManager : MonoBehaviour, IRequest<Token>
    {
        public ScreenManager screenManager;
        public WarningManager warningManager;

        string tokenPrefKey = "tokenPrefKey";
        string token = "";
        TokenPayload tokenPayload;

        void Awake()
        {
            // load/read token
            LoadTokenFromDevice(); // if connected to the internet
        }

        #region Irequest
        public void OnRequestError(string error)
        {
            // show error
            warningManager.ShowWarning("Error on connecting to server", error);
        }

        public void OnRequestSuccess(Token token)
        {
            SaveToken(token);
        }

        #endregion
        public void SaveToken(Token token)
        {
            // save token
            PlayerPrefs.SetString(tokenPrefKey, token.token);
            LoadTokenFromDevice();
        }
        void LoadTokenFromDevice()
        {
            // show loading panel
            screenManager.ChangeScreen(ScreenTypes.LOADING);
            // read token from device
            string token = PlayerPrefs.GetString(tokenPrefKey);
            this.token = token;
            // parse token
            tokenPayload = ParseToken(token);

            if (tokenPayload != null)
            {
                // check expire date
                DateTime expiredDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(tokenPayload.exp);

                double diff = expiredDate.Subtract(DateTime.UtcNow).TotalHours;
                if( diff < 50 )
                {
                    // refresh token
                        HttpRequest<Token> req = new HttpRequest<Token>(HttpConstants.TOKEN_REFRESH,
                    new Dictionary<string, string> { { "id", tokenPayload.id }, },
                    new Dictionary<string, string> { { HttpConstants.TOKEN_KEY, HttpConstants.TOKEN_KEY_VALUE}, },
                    this);
                }
                else
                {
                    // get user information
                    Debug.Log("GetUser Information");
                    //screenManager.ChangeScreen(ScreenTypes.HOME); // this should calling from user manager
                }
            }
            else
            {
                // show login panel
                screenManager.ChangeScreen(ScreenTypes.LOGIN);
            }
        }

        TokenPayload ParseToken(string token)
        {
            var parts = token.Split('.');
            if (parts.Length > 2)
            {
                var decode = parts[1];
                var padLength = 4 - decode.Length % 4;
                if (padLength < 4)
                {
                    decode += new string('=', padLength);
                }
                var bytes = Convert.FromBase64String(decode);
                var payload = Encoding.ASCII.GetString(bytes);

                return JsonUtility.FromJson<TokenPayload>(payload);
            }

            return null;
        }
    }
}
