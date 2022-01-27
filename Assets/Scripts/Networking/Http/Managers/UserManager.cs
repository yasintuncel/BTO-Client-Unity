// created by yasintuncel
using BattleTacticsOnline.Managers;
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Infrastructure.Delegates;
using BattleTacticsOnline.Networking.Http.Models;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTacticsOnline.Networking.Http.Managers
{
    public class UserManager : MonoBehaviour, IRequest<User>
    {
        public ScreenManager screenManager;
        public DUserLogin dUserLogin;
        User user;
        string token;
        public void GetUserInformation(string token)
        {
            this.token = token;
            // get user information

            HttpModel<User> tokenHttpModel = new HttpModel<User>
            {
                url = HttpConstants.USER_INFORMATION,
                headerParams = new Dictionary<string, string> { { HttpConstants.AUTH_KEY, token }, },
                postParams = new Dictionary<string, string> { },
                iRequest = this
            };
            StartCoroutine(ConstantFunctions.Post(tokenHttpModel));
        }

        #region Irequest
        public void OnRequestError(string error)
        {
            Debug.LogError(error);
            GetUserInformation(token);
        }

        public void OnRequestSuccess(User user)
        {
            screenManager.ChangeScreen(ScreenTypes.HOME);
            this.user = user;
            dUserLogin?.Invoke(user);
        }
        #endregion
    }
}
