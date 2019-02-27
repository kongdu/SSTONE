using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TMI
{
    public class MonsterMove : MonoBehaviour
    {
        private Vector3 destination;

        public NavMeshAgent navMeshAgent;
        private float jumpSpeed;

        private void Awake()
        {
            jumpSpeed = Random.Range(3f, 6f);
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent == null)
            {
                Debug.Log(gameObject.name + "에는 네비에이전트가 없다");
            }
            else
            {
                navMeshAgent.isStopped = true;
                //SetDestination();
            }
        }

        /// <summary>
        /// 네비매시의 목적지를 탐색
        /// </summary>
        public void SetDestination()
        {
            if (destination != null)
            {
                Vector3 targetVector = Player.Instance.transform.position;
                navMeshAgent.SetDestination(targetVector);
            }
            else
            {
                destination = Player.Instance.transform.position;
            }
        }

        private void Update()
        {
            float dis = Vector3.Distance(transform.position, destination);

            if (dis < 20f)
            {
                GetComponent<Move>().SomethingHappen();
            }

            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * jumpSpeed, 3), transform.position.z);
        }

        /// <summary>
        /// 네비메시의 켜짐꺼짐
        /// </summary>
        /// <param name="onoff">true=꺼짐,false=켜짐</param>
        public void NavOnOff(bool onoff)
        {
            if (gameObject.activeInHierarchy &&
                navMeshAgent != null &&
                navMeshAgent.enabled)
                navMeshAgent.isStopped = onoff;
        }

        private struct LaunchData
        {
            public readonly Vector3 initialVelocity;
            public readonly float timeToTarget;

            public LaunchData(Vector3 initialVelocity, float timeToTarget)
            {
                this.initialVelocity = initialVelocity;
                this.timeToTarget = timeToTarget;
            }
        }

        private LaunchData CalculateLaunchData()
        {
            float h = 20;
            float gravity = 9f;

            float displacementY = destination.y - transform.localPosition.y;
            Vector3 displacementXZ = new Vector3(destination.x - transform.localPosition.x, 0, destination.z - transform.localPosition.z);
            float time = (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));
            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
            Vector3 velocityXZ = displacementXZ / time;
            return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
        }
    }
}