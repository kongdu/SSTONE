using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    /// <summary>
    /// GameStartPanel 프리팹에 붙일 스크립트
    /// </summary>
    public class StartPanel : MonoBehaviour
    {
        public void OnHitPanel()
        {
            GameManager.Instance.gameStartEnd?.Invoke();
        }
    }
}