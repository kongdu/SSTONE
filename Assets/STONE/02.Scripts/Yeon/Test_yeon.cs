using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Test_yeon : MonoBehaviour
    {
        private void OnEnable()
        {
            ViveController.OnTouchPadSwipe += SwipeTest;
            ViveController.OnTouchPadClickLeft += LeftClickTest;
            ViveController.OnTouchPadClickRight += RightClickTest;
        }

        private void OnDisable()
        {
            ViveController.OnTouchPadSwipe -= SwipeTest;
            ViveController.OnTouchPadClickLeft -= LeftClickTest;
            ViveController.OnTouchPadClickRight -= RightClickTest;
        }

        private void SwipeTest(float angle)
        {
            Debug.Log("스와이프 성공!!  " + angle);
        }

        private void LeftClickTest()
        {
            Debug.Log("왼쪽 클릭 성공");
        }

        private void RightClickTest()
        {
            Debug.Log("오른쪽 클릭 성공");
        }
    }
}