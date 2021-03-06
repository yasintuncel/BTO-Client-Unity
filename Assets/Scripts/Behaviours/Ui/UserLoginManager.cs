// created by yasintuncel
using BattleTacticsOnline.Networking;
using BattleTacticsOnline.Networking.Http;
using BattleTacticsOnline.Networking.Http.Infrastructure.Delegates;
using BattleTacticsOnline.Networking.Http.Managers;
using BattleTacticsOnline.Networking.Http.Models;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Ui
{
    public class UserLoginManager : MonoBehaviour, IUserLogin
    {
        public UserManager userManager;
        [Space]
        public Text txtName;
        public Text txtLevel;
        public Text txtGold;
        [Space]
        public Image imgProfile;

        private void OnEnable()
        {
            userManager.dUserLogin += OnUserLogin;
        }
        private void OnDisable()
        {
            userManager.dUserLogin -= OnUserLogin;
        }

        async Task GetProfilePicture(string url)
        {
             Sprite sp = await ConstantFunctions.GetRemoteTexture(url);

            if(sp != null)
            {
                imgProfile.sprite = sp;
            }
        }

        public void OnUserLogin(User user)
        {
            txtName.text = user.nickName;
            txtLevel.text = "" + user.level.level;
            txtGold.text = "" + user.gold.amount;
            _ = GetProfilePicture(HttpConstants.IDENTICONS + "/" + user.identicon + ".png");
        }

        public void OnUserLogout()
        {
            Debug.Log("user logout");
        }

    }
}
