using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-900)]
    public class Pathlist : MonoBehaviour
    {
        public List<Vector3> pathlist;
        public GameObject pointList;

        private void Awake()
        {
            pathlist = new List<Vector3>();
            Listup(pointList);
        }

        /// <summary>
        /// 리스트에서 랜덤한 좌표 하나를 팝해줌
        /// </summary>
        /// <returns></returns>
        public Vector3 Pop()
        {
            int randomValue = Random.Range(0, pathlist.Count);
            return pathlist[randomValue];
        }

        private void Listup(GameObject pointList)
        {
            Transform[] tt = pointList.GetComponentsInChildren<Transform>();
            foreach (var item in tt)
            {
                pathlist.Add(item.position);
            }
        }

        #region Gizmos

        [ColorUsage(false, true)]
        public Color gizmosColor = Color.red;

        [Range(0.01f, 10f)]
        public float gizmosRadius = 1f;

        private void OnDrawGizmosSelected()
        {
            var oldColor = Gizmos.color;
            Gizmos.color = gizmosColor;
            {
                foreach (var v in pathlist)
                    Gizmos.DrawSphere(v, gizmosRadius);
            }
            Gizmos.color = oldColor;
        }

        #endregion Gizmos
    }
}