using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMI
{
    public class ScoreUI : MonoBehaviour
    {
        public Text text;
        private int score = 0;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void ScorePlus()
        {
            Score++;
            text.text = "점수" + Score;
        }
    }
}