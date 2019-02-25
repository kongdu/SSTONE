using UnityEngine;

public class Dead : State
{
    public override void Enter()
    {
        Debug.Log("난 죽었다");

        if (TMI.StoneBase.type == TMI.StoneBase.StoneType.Dimement)
            StartCoroutine(TMI.GameEffectManager.Instance.DimementEffect(transform));
        else
            StartCoroutine(TMI.GameEffectManager.Instance.LaserEffect(transform));
    }

    public override void Exit()
    {
    }
}