// created by yasintuncel
using BattleTacticsOnline.Networking.Http;
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Managers
{
    public class LoginManager : MonoBehaviour, IRequest<Token>
    {
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

            StartCoroutine(req.Post());
        }

        #region IRequest
        public void OnRequestError(string error)
        {
            Debug.LogError(error);
        }

        public void OnRequestSuccess(Token token)
        {
            Debug.Log(token.token);
        }
        #endregion
    }
}
