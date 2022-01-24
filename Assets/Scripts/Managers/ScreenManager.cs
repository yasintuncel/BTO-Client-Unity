// created by yasintuncel
using System;
using UnityEngine;

namespace BattleTacticsOnline.Managers
{
    public enum ScreenTypes
    {
        NONE,
        LOGIN,
        LOADING,
        HOME
    }

    [Serializable]
    public class ScreenObject
    {
        public ScreenTypes screenType;
        public GameObject screen;
    }

    public class ScreenManager : MonoBehaviour
    {
        public ScreenObject[] screens;

        private ScreenTypes previousScreenType = ScreenTypes.NONE;

        public void ChangeScreen(ScreenTypes type)
        {
            if (previousScreenType == type)
                return;

            foreach (ScreenObject screen in screens)
            {
                if (screen.screenType == type)
                    screen.screen.SetActive(true);
                else
                    screen.screen.SetActive(false);
            }
        }
    }
}
