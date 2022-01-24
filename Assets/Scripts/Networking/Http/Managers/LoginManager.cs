// created by yasintuncel
using BattleTacticsOnline.Managers;
using BattleTacticsOnline.Networking.Http;
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Networking.Http.Managers
{
    public class LoginManager : MonoBehaviour, IRequest<Token>
    {
        public TokenManager tokenManager;
        public WarningManager warningManager;
        public ScreenManager screenManager;
        [Space]
        public Button btnLogin;
        public InputField fieldNickName;

        private void Awake()
        {
            btnLogin.onClick.AddListener(OnClickLogin);
        }

        private void OnClickLogin()
        {
            string nickName = fieldNickName.text;

            HttpRequest<Token> req = new HttpRequest<Token>(HttpConstants.REGISTER_AS_GUEST,
                new Dictionary<string, string> { { "nickName", nickName }, },
                new Dictionary<string, string> { { HttpConstants.REGISTER_KEY, HttpConstants.REGISTER_KEY_VALUE }, },
                this);
            screenManager.ChangeScreen(ScreenTypes.LOADING);
            StartCoroutine(req.Post());
        }

        #region IRequest
        public void OnRequestError(string error)
        {
            Debug.LogError(error);
            warningManager.ShowWarning("Error on Login", error);
            screenManager.ChangeScreen(ScreenTypes.LOGIN);
        }

        public void OnRequestSuccess(Token token)
        {
            Debug.Log(token.token);
            // save token
            tokenManager.SaveToken(token);

        }
        #endregion
    }
}
