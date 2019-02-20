using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-20000)]
    public class PathDataBase : Singleton<PathDataBase>
    {
        public Queue<IEnumerator<Vector3>> completedPathlist;
        //public Vector3 playerVector;

        private void Awake()
        {
            completedPathlist = new Queue<IEnumerator<Vector3>>();
            //  playerVector = new Vector3(0, 0, 0);
        }
    }
}