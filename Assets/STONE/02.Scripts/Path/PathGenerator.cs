using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class PathGenerator : MonoBehaviour
    {
        //경로를 전부 가지고 있는 리스트
        [SerializeField]
        public List<Pathlist> pathlist;

        public PathDataBase pathDataBase;

        /// <summary>
        /// 랜덤경로만들어서 PathDataBase의 pathlist에다가 이터레이터형태로 집어넣음
        /// </summary>
        /// <param name="times">만들어낼 경로의 수</param>
        private void Awake()
        {
            GetPath(3);
        }

        public void GetPath(int times)
        {
            pathDataBase = new PathDataBase();
            // 경로데이타베이스만들고 경로 생성될때마다 리스트 업시킴
            for (int i = 0; i < times; i++)
            {
                var path = CreateIterator(RandomPathGenerater(pathlist));
                pathDataBase.pathlist.Add(path);
            }
        }

        private List<Transform> RandomPathGenerater(List<Pathlist> pathlist)
        {
            List<Transform> randompathlist = new List<Transform>();
            for (int i = 0; i < pathlist.Count; i++)
            {
                var path = pathlist[i].Pop();
                randompathlist.Add(path);
            }
            return randompathlist;
        }

        //새로운 리스트를 이터레이터로 바꿔서 리턴하는 기능
        private IEnumerator<Transform> CreateIterator(List<Transform> pathlist)
        {
            var path = pathlist.GetEnumerator();
            return path;
        }
    }
}