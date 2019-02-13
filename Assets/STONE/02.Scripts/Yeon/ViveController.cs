using UnityEngine;
using HTC.UnityPlugin.Vive;
using System;
using UnityEngine.Events;

namespace TMI
{
    public class ViveController : MonoBehaviour
    {
        public static event Action OnTouchPadClickLeft, OnTouchPadClickRight;

        public static event Action<float> OnTouchPadSwipe;

        private const float touchpadDeadzoneRadius = 0.15f; //데드존은 30%
        private Vector2 center = new Vector2(0.0f, 0.0f);
        private Vector2 currentPoint;
        private Vector2 prevPoint;

        private void Update()
        {
            //오른손 Trigger Button
            if (ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                Debug.Log("Right Hand Trigger Button Down!");
            }

            // 왼손 트랙패드 제스처 옵션 총 두가지
            // i) trackpad Click: 트랙패드 원 좌우로 나눠서 왼쪽/오른쪽
            // ii) 트랙패드 Swipe: 시작~도착점 사이의 거리,각으로 방향계산 (시계swipe: +, 반시계swipe: -)

            ClickPadforSelecting();
            SwipePadforSelecting();
        }

        private bool CheckDeadzone(Vector2 leftPadDir, float radius)
        {
            float distance = (leftPadDir - center).magnitude;

            if (distance <= radius)
            {
                //Debug.Log("Deadzone True");
                return true;
            }
            else
            {
                //Debug.Log("Deadzone false");
                return false;
            }
        }

        private float SwipeInput(Vector2 startPoint, Vector2 endPoint)
        {
            return -(Vector2.SignedAngle(startPoint, endPoint));
        }

        // i) Click 구현
        private void ClickPadforSelecting()
        {
            if (ViveInput.GetPressDownEx(HandRole.LeftHand, ControllerButton.Pad))
            {
                currentPoint = ViveInput.GetPadPressAxisEx(HandRole.LeftHand);
                if (currentPoint != Vector2.zero)
                {
                    if (currentPoint.x < 0.0f)
                    {
                        OnTouchPadClickLeft?.Invoke();
                    }
                    else
                    {
                        OnTouchPadClickRight?.Invoke();
                    }
                }
            }
        }

        // ii) Swipe 구현
        /// <summary>
        ///
        /// </summary>
        private void SwipePadforSelecting()
        {
            if (ViveInput.GetPressEx(HandRole.LeftHand, ControllerButton.Pad))
                return;
            if (!ViveInput.GetPressEx(HandRole.LeftHand, ControllerButton.PadTouch))
                return;
            if (ViveInput.GetPressDownEx(HandRole.LeftHand, ControllerButton.Pad))
                return;
            if (ViveInput.GetPressUpEx(HandRole.LeftHand, ControllerButton.Pad))
                return;

            currentPoint = ViveInput.GetPadAxisEx(HandRole.LeftHand);
            if (CheckDeadzone(currentPoint, touchpadDeadzoneRadius))
            {
                //Debug.Log("데드존에서 아무 일도 일어나지 않음");
            }
            else
            {
                var angle = SwipeInput(prevPoint, currentPoint);
                if (Mathf.Abs(angle) > 0.2f)
                    OnTouchPadSwipe?.Invoke(angle);
            }

            prevPoint = currentPoint;
        }
    }
}