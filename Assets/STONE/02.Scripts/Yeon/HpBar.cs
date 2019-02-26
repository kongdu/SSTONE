using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMI
{
    [DefaultExecutionOrder(-10)]
    public class HpBar : MonoBehaviour
    {
        public Color fullColor = Color.green;
        public Color emptyColor = Color.red;

        private Slider healthSlider;
        private Image fillImage;

        private void Awake()
        {
            healthSlider = GetComponentInChildren<Slider>();
            healthSlider.value = healthSlider.maxValue;

            var images = GetComponentsInChildren<Image>();
            foreach (var i in images)
            {
                if (i.gameObject.name == "Fill")
                {
                    fillImage = i;
                    break;
                }
            }
            fillImage.color = fullColor;
        }

        /// <summary>
        /// 매개변수로 들어오는 퍼센트만큼 hpBar 보여주기
        /// </summary>
        /// <param name="percent">0.0 ~ 1.0</param>
        public void ShowHpBar(float percent)
        {
            healthSlider.value = percent;
            fillImage.color = Color.Lerp(emptyColor, fullColor, percent);
        }
    }
}