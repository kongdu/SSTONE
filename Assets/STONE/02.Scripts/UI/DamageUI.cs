using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMI
{
    public class DamageUI : MonoBehaviour
    {
        public Text text;
        private int damageScore = 0;

        public void DamagePlus()
        {
            damageScore++;
            text.text = "Damage" + damageScore;
        }
    }
}