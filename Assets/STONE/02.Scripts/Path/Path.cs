using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public static class Path
    {
        public static List<Vector3> Build(Vector3 pivot)
        {
            var res = new List<Vector3>();

            // 첫번째 포인트 생성
            var firstPoint = FindFarPoint(pivot);
            res.Add(firstPoint);

            /// 두세네....번째 포인트 생성

            // 마지막 포인트 생성
            res.Add(pivot);

            return res;
        }

        /// <summary>
        /// pivot 기준으로 최소 거리 ~ 최대 거리 사이에 무작위로 위치 생성
        /// </summary>
        /// <returns>생성된 위치</returns>
        public static Vector3 FindFarPoint(Vector3 pivot, float minDistance = 80f, float maxDistance = 99f)
        {
            float distance = Random.Range(minDistance, maxDistance);
            float angle = Random.Range(0f, 360f);
            float radian = angle * Mathf.Deg2Rad;
            return pivot + (new Vector3(Mathf.Cos(radian), 0f, Mathf.Sin(radian)) * distance);
        }
    }
}