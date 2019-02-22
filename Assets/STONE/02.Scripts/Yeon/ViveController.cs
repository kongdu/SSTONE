using UnityEngine;
using HTC.UnityPlugin.Vive;
using System;
using UnityEngine.Events;

namespace TMI
{
    public class ViveController : MonoBehaviour
    {
        public static event Action OnClickPad_LeftSide, OnClickPad_RightSide;

        public static event Action<float> OnTouchPadSwipe;

        public static event Action OnPressDownTrigger_RightHand;//, OnPressTrigger_RightHand, OnPressUpTrigger_RightHand;

        private Module[] modules = new Module[] { new PadModule(), new TriggerModule() };

        private void Update()
        {
            foreach (var m in modules)
                m.Process();
        }

        #region Modules

        private abstract class Module
        {
            public abstract void Process();
        }

        private class PadModule : Module
        {
            private const float deadzoneRadiusOfTouchPad = 0.15f; //데드존은 터치패드의 가운데 30%
            private static Vector2 center = new Vector2(0.0f, 0.0f);
            private static Vector2 currentPoint;
            private static Vector2 prevPoint;

            // [왼손 터치패드] 두 가지 옵션 : (i) Click (ii) Swipe
            public override void Process()
            {
                DetectClickingPad(HandRole.LeftHand);
                DetectSwipingPad(HandRole.LeftHand);
            }

            // i) TouchPad Click 구현
            /// <summary>
            /// 트랙패드의 클릭을 감지(트랙패드 원을 딱 반으로 나눠서 왼쪽/오른쪽 구분)해서 연결된 이벤트 실행
            /// </summary>
            /// <param name="handSide">터치를 감지할 손</param>
            private static void DetectClickingPad(HandRole handSide)
            {
                if (ViveInput.GetPressDownEx(handSide, ControllerButton.Pad))
                {
                    currentPoint = ViveInput.GetPadPressAxisEx(handSide);
                    if (currentPoint != Vector2.zero)
                    {
                        if (currentPoint.x < 0.0f)
                            OnClickPad_LeftSide?.Invoke();
                        else
                            OnClickPad_RightSide?.Invoke();
                        //((currentPoint.x < 0.0f) ? OnClickPad_LeftSide : OnClickPad_RightSide)?.Invoke();
                    }
                }
            }

            // ii) TouchPad Swipe 구현
            /// <summary>
            /// 트랙패드의 스와이프를 감지(시계/반시계 구분)해서 연결된 이벤트 실행
            /// </summary>
            /// <param name="handSide">스와이프를 감지할 손</param>
            private static void DetectSwipingPad(HandRole handSide)
            {
                if (ViveInput.GetPressEx(handSide, ControllerButton.Pad))
                    return;
                if (!ViveInput.GetPressEx(handSide, ControllerButton.PadTouch))
                    return;
                if (ViveInput.GetPressDownEx(handSide, ControllerButton.Pad))
                    return;
                if (ViveInput.GetPressUpEx(handSide, ControllerButton.Pad))
                    return;

                currentPoint = ViveInput.GetPadAxisEx(handSide);
                if (CheckDeadzone(currentPoint, deadzoneRadiusOfTouchPad))
                {
                    //Debug.Log("데드존을 스와이프하면 아무 일도 일어나지 않음");
                }
                else
                {
                    var angle = SwipeInput(prevPoint, currentPoint);
                    if (Mathf.Abs(angle) > 0.2f)
                        OnTouchPadSwipe?.Invoke(angle);
                }

                prevPoint = currentPoint;
            }

            private static bool CheckDeadzone(Vector2 leftPadDir, float radius)
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

            private static float SwipeInput(Vector2 startPoint, Vector2 endPoint)
            {
                return -(Vector2.SignedAngle(startPoint, endPoint));
            }
        }

        private class TriggerModule : Module
        {
            // [오른손 트리거 버튼]
            public override void Process()
            {
                DetectTriggerButton(HandRole.RightHand);
            }

            /// <summary>
            /// 오른손 트리거를 감지해서 연결된 이벤트 실행
            /// </summary>
            /// <param name="handSide">트리거를 감지할 손</param>
            private static void DetectTriggerButton(HandRole handSide)
            {
                if (ViveInput.GetPressDownEx(handSide, ControllerButton.Trigger))
                {
                    OnPressDownTrigger_RightHand?.Invoke();
                }
            }
        }

        #endregion Modules
    }
}