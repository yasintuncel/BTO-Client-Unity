// created by yasintuncel
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Managers.Screens
{
    public class HomeScreenManager : MonoBehaviour
    {
        public GameObject[] homeScreenPanels;
        [Space]
        public Button btnFriend;
        public GameObject pnlFriend;
        private void Awake()
        {
            foreach (var obj in homeScreenPanels)
            {
                obj.SetActive(false);
            }
            btnFriend.onClick.AddListener(OnClickFriend);
        }

        private void OnClickFriend()
        {
            pnlFriend.SetActive(!pnlFriend.activeSelf);
        }
    }
}
