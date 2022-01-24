// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Infrastructure;
using BattleTacticsOnline.Networking.Http.Models;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTacticsOnline.Networking.Http.Managers
{
    public class UserManager : MonoBehaviour, IRequest<User>
    {
        User user;

        public void GetUserInformation(string token)
        {
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
        }

        public void OnRequestSuccess(User user)
        {
            this.user = user;
        }
        #endregion
    }
}
