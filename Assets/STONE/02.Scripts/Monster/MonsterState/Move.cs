using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    private MonsterMove mm;

    private void Awake()
    {
        mm = GetComponent<MonsterMove>();
    }

    public override void Enter()
    {
        mm.OnOff(false);
    }

    public override void Exit()
    {
        mm.OnOff(true);
    }
}