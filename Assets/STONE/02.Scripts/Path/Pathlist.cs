using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Pathlist : MonoBehaviour
    {
        public List<Transform> pathlist;

        public Transform Pop()
        {
            int randomValue = Random.Range(0, pathlist.Count);
            return pathlist[randomValue];
        }
    }
}