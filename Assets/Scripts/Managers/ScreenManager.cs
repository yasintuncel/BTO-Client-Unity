// created by yasintuncel
using UnityEngine;

namespace BattleTacticsOnline.Managers
{
    public class ScreenManager : MonoBehaviour
    {
        public GameObject pnlLogin;
        public GameObject pnlLoadging;

        public void ShowLoadingPanel()
        {
            if (!pnlLoadging.activeSelf)
                pnlLoadging.SetActive(true);
        }

        public void ShowLoginPanel()
        {
            if (!pnlLogin.activeSelf)
                pnlLogin.SetActive(true);
            pnlLoadging.SetActive(false);
        }
        public void HideLoginPanel()
        {
            pnlLogin.SetActive(false);
            pnlLoadging.SetActive(false);
        }
    }
}
