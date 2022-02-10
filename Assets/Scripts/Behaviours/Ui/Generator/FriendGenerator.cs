// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Infrastructure.Delegates;
using BattleTacticsOnline.Networking.Http.Managers;
using BattleTacticsOnline.Networking.Http.Models;
using BattleTacticsOnline.Networking.Http.Models.FriendModels;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTacticsOnline.Behaviours.Ui.Generator
{
    public class FriendGenerator : MonoBehaviour, IUserLogin
    {
        public UserManager userManager;
        [Space]
        public GameObject friendParent;
        public GameObject prefabPanelFriend;

        List<Friend> friends = new List<Friend>();

        private void OnEnable()
        {
            userManager.dUserLogin += OnUserLogin;
        }
        private void OnDisable()
        {
            userManager.dUserLogin -= OnUserLogin;
        }

        public void OnUserLogin(User user)
        {
            friends = user.friends;
            GenerateFriendPanels();
        }

        public void OnUserLogout()
        {
            // clear childs of friend parent panel
        }

        private void GenerateFriendPanels()
        {
            foreach (Friend firend in friends)
            {
                GameObject pnlFriend = Instantiate(prefabPanelFriend);
                pnlFriend.transform.SetParent(friendParent.transform);
                FriendPanelManager fpm = pnlFriend.GetComponent<FriendPanelManager>();
                fpm.SetFriend(firend);
            }
        }
    }
}
