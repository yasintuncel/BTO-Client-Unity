// created by yasintuncel
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTacticsOnline.Managers
{
    public class WarningManager : MonoBehaviour
    {
        public GameObject pnlWarning;
        [SerializeField] private int showDuration = 2;

        public Text txtTitle;
        public Text txtDescription;

        public void ShowWarning(string title, string description)
        {
            txtTitle.text = title;
            txtDescription.text = description;
            StartCoroutine(Showpanel());
        }

        IEnumerator Showpanel()
        {
            pnlWarning.SetActive(true);
            yield return new WaitForSeconds(showDuration);
            pnlWarning.SetActive(false);
        }
    }
}
