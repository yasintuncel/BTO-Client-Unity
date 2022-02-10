// created by yasintuncel
using BattleTacticsOnline.Managers;
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
            screenManager.ChangeScreen(ScreenTypes.LOADING);

            string nickName = fieldNickName.text;
            
            HttpModel<Token> tokenHttpModel = new HttpModel<Token>{
                url = HttpConstants.REGISTER_AS_GUEST,
                headerParams = new Dictionary<string, string> { { HttpConstants.REGISTER_KEY, HttpConstants.REGISTER_KEY_VALUE }, },
                postParams = new Dictionary<string, string> { { "nickName", nickName }, },
                iRequest = this
            };
            StartCoroutine(ConstantFunctions.Post(tokenHttpModel));
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
