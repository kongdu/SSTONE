using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : Singleton<StopWatch>
{
    private float comboStopCount = 5;

    private void Start()
    {
        StartProcess();
    }

    private void StartProcess()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        while (true)
        {
            comboStopCount = comboStopCount - 1 * Time.deltaTime;
            Debug.Log(comboStopCount);
            if (comboStopCount <= 0)
            {
                comboStopCount = 5;
                break;
            }
            yield return null;
        }
    }
}