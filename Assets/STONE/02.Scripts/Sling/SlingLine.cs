using System;
using UnityEngine;

namespace TMI
{
    public class SlingLine : Singleton<SlingLine>
    {
        private SpringJoint joint;

        private LineRenderer[] lineRenderers;

        public Func<SpringJoint> Findjoint => () => joint = FindObjectOfType<SpringJoint>();

        private Action FindLines => () => lineRenderers = GetComponentsInChildren<LineRenderer>();

        private Action linefirst;

        private Action lineLast;

        private void OnEnable()
        {
            linefirst += InitialLineRend;
            lineLast += LastLineRend;
        }

        private void OnDisable()
        {
            linefirst -= InitialLineRend;
            lineLast -= LastLineRend;
        }

        private void Awake()
        {
            FindLines?.Invoke();
            Findjoint?.Invoke();
        }

        private void Update()
        {
            linefirst?.Invoke();
            lineLast?.Invoke();
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
}