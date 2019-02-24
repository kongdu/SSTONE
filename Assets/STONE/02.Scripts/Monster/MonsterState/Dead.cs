using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : State
{
    public override void Enter()
    {
        Debug.Log("난 죽었다");
    }
}