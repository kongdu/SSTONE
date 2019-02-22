using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    /// <summary>
    /// 빔 이동 모습 그리기
    /// 라인렌더러가 붙은 게임오브젝트에 붙이는 스크립트
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererEffect : MonoBehaviour
    {
        private LineRenderer line;
        public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam

        private void Awake()
        {
            line = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            //빔 이동
            line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
        }
    }
}