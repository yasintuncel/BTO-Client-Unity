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
            HttpRequest<User> req = new HttpRequest<User>(HttpConstants.USER_INFORMATION,
            new Dictionary<string, string> { },
            new Dictionary<string, string> { { HttpConstants.AUTH_KEY, token }, },
            this);

            StartCoroutine(req.Post());
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
