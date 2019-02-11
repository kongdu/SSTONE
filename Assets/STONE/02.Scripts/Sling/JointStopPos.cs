using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointStopPos : MonoBehaviour
{
    public Transform pivot;
    /// <summary>
    /// 투사체 발사후 호출하면 조인트가 (pivot)원래 위치로 복원됨
    /// </summary>
    public Action<Transform> JointResetPosition => 
                    (pivot) => transform.position = pivot.position;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            JointResetPosition(pivot);
    }
}
