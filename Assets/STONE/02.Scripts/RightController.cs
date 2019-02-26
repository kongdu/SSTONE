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
            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPressDown?.Invoke();
            }
            else if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPress?.Invoke();
            }
            else if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger))
            {
                ControllerPressUp?.Invoke();
            }
        }
    }
}