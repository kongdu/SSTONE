using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class PathDataBase
    {
        public List<IEnumerator<Transform>> pathlist = new List<IEnumerator<Transform>>();
    }
}