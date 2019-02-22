using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TMI
{
    /// <summary>
    /// 몬스터에 붙일 스크립트
    /// </summary>
    public class Hittable : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnHitEvent;

        public void OnHit()
        {
            Debug.Log("OnHit() 실행됐다");
            OnHitEvent?.Invoke();
        }
    }
}