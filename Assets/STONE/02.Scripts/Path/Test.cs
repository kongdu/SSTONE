using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float gizmosSize = 1f;
    public Vector3 pivot;
    public int count = 10;
    public float minDistance = 80f;
    public float maxDistance = 99f;
    public List<Vector3> pathList = new List<Vector3>();
    public List<float> distanceList = new List<float>();

    private void OnValidate()
    {
        pathList.Clear();
        distanceList.Clear();

        //for (int i = 0; i < count; i++)
        //{
        //    var point = TMI.Path.FindFarPoint(pivot, minDistance, maxDistance);
        //    pathList.Add(point);
        //    distanceList.Add(point.magnitude);
        //}

        var path = TMI.Path.Build(pivot);
        transform.position = path[0];
        path.RemoveAt(0);

        var doTweenPath = GetComponent<DOTweenPath>();
        doTweenPath.wps = path;
    }

    public void Play()
    {
        var doTweenPath = GetComponent<DOTweenPath>();
        doTweenPath.DOPlay();
    }

    private void OnDrawGizmosSelected()
    {
        if (pathList == null)
            return;

        Gizmos.color = Color.blue;
        foreach (var p in pathList)
        {
            Gizmos.DrawSphere(p, gizmosSize);
        }
        Gizmos.color = Color.white;
    }
}