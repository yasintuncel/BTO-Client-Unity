// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Models.FriendModels;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Behaviours.Ui
{
    public class FriendPanelManager : MonoBehaviour
    {
        [Space]
        public Text txtName;
        public Text txtLevel;
        public Text txtGold;
        public Text txtPlayCount;
        [Space]
        public Image imgProfile;
        [Space]
        public Button btnOptions;
        public Button btnMessage;
        public Button btnPlay;
        public Button btnOther;
        [Space]
        public GameObject pnlOptions;

        private void Awake()
        {
            btnOptions.onClick.AddListener(OnClickOptions);
            btnMessage.onClick.AddListener(OnClickMessage);
            btnPlay.onClick.AddListener(OnClickPlay);
            btnOther.onClick.AddListener(OnClickOther);
        }

        public void SetFriend(Friend friend)
        {
            txtName.text = friend.user.nickName;
            txtLevel.text = "" + friend.user.level.level;
            txtGold.text = "" + friend.user.gold.amount;
            txtPlayCount.text = "" + friend.playCount;
            Debug.Log(JsonUtility.ToJson(friend));
        }
        private void OnClickOptions()
        {
            pnlOptions.SetActive(!pnlOptions.activeSelf);
        }

        private void OnClickMessage()
        {
            Debug.Log("btn Messager");
        }

        private void OnClickPlay()
        {
            Debug.Log("btn Play");
        }

        private void OnClickOther()
        {
            Debug.Log("btn Other");
        }
    }
}
