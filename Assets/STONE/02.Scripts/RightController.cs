using HTC.UnityPlugin.Vive;
using System;
using UnityEngine;

namespace TMI
{
    public class RightController : MonoBehaviour
    {
        public static Action ControllerPressDown = () => { };

        public static Action ControllerPress = () => { };

        public static Action ControllerPressUp = () => { };

        // Update is called once per frame
        private void Update()
        {
            if (ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPressDown?.Invoke();
            }
            if (ViveInput.GetPressEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPress?.Invoke();
            }

            if (ViveInput.GetPressUpEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPressUp?.Invoke();
            }
        }
    }
}