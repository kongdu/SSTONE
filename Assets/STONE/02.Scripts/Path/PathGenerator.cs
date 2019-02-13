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

        // 리스트에서 순서대로 랜덤한 값 추출해서 새로운 리스트를 만드는 기능
        public IEnumerator<Transform> GetPath()
        {
            var path = CreateIterator(RandomPathGenerater(pathlist));
            return path;
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