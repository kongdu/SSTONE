using UnityEngine;
using UnityEngine.UI;

namespace TMI
{
    public class Achievements : MonoBehaviour
    {
        [HideInInspector] public int KillCount;
        public Text killCountTxt;

        private void Start()
        {
            KillCount = UIManager.Instance.scoreUI.Score;
        }
    }
}