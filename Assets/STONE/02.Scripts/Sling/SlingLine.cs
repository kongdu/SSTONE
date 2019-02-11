using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingLine : Singleton<SlingLine>
{
    private SpringJoint joint;

    private LineRenderer[] lineRenderers;

    public Func<SpringJoint> Findjoint => () => { return joint = FindObjectOfType<SpringJoint>(); };

    private Action FindLines => () => lineRenderers = FindObjectsOfType<LineRenderer>();

    private Action SlinglinePos;

    private void Awake()
    {
        FindLines?.Invoke();
        Findjoint?.Invoke();

        MethodChain(InitialLineRend, true);

        SlinglinePos?.Invoke();

        MethodChain(InitialLineRend, false);

        MethodChain(LastLineRend, true);
    }

    private void Update()
    {
        SlinglinePos?.Invoke();
    }

    /// <summary>
    /// 연결할 메소드, True(연결)/False(해제)
    /// </summary>>
    private void MethodChain(Action action, bool flag)
    {
        if (flag) SlinglinePos += action;
        else SlinglinePos -= action;
    }

    private void InitialLineRend()
    {
        foreach (var item in lineRenderers)
            item.SetPosition(0, item.transform.position);
    }

    private void LastLineRend()
    {
        foreach (var item in lineRenderers)
            item.SetPosition(1, joint.transform.position);
    }
}