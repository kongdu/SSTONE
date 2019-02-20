using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-800)]
    public class PathGenerator : MonoBehaviour
    {
        [SerializeField]
        public List<Pathlist> pathlist;

        /// <summary>
        /// 랜덤경로만들어서 PathDataBase의 pathlist에다가 이터레이터형태로 집어넣음
        /// </summary>
        /// <param name="times">만들어낼 경로의 수</param>

        private void Awake()
        {
            GenPath(1000);
        }

        public void GenPath(int times)
        {
            for (int i = 0; i < times; i++)
            {
                var path = CreateIterator(RandomPathGenerater(pathlist));
                PathDataBase.Instance.completedPathlist.Enqueue(path);
                Debug.Log(PathDataBase.Instance.completedPathlist.Count);
            }
        }

        private List<Vector3> RandomPathGenerater(List<Pathlist> pathlist)
        {
            List<Vector3> randompathlist = new List<Vector3>();
            for (int i = 0; i < pathlist.Count; i++)
            {
                var path = pathlist[i].Pop();
                randompathlist.Add(path);
            }
            return randompathlist;
        }

        // 새로운 리스트를 이터레이터로 바꿔서 리턴하는 기능
        private IEnumerator<Vector3> CreateIterator(List<Vector3> pathlist)
        {
            var path = pathlist.GetEnumerator();
            return path;
        }
    }
}