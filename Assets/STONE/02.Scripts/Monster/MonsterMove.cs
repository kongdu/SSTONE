using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private Transform destination;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.Log(gameObject.name + "에는 네비에이전트가 없다");
        }
        else
        {
            navMeshAgent.isStopped = true;
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
        else
        {
            destination.position = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 3, 3), transform.position.z);
    }

    /// <summary>
    /// 켜짐꺼짐
    /// </summary>
    /// <param name="onoff">true=꺼짐,false=켜짐</param>
    public void OnOff(bool onoff)
    {
        navMeshAgent.isStopped = onoff;
    }
}