using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TMI
{
    /// <summary>
    /// 돌 프리팹에 붙일 스크립트
    /// </summary>
    public class LaserBeamController : StoneBase
    {
        public float resetDelay = 1f;
        public float rendererOffDelay = 0.5f;

        private LaserBeam laserBeam;

        private void Awake()
        {
            laserBeam = GetComponent<LaserBeam>();
            rb = GetComponent<Rigidbody>();
        }

        public override void Shot()
        {
            laserBeam.ShootLaserBeam();

            StopAllCoroutines();

            StartCoroutine(RendererOffProcess());
            StartCoroutine(ResetProcess());
        }

        private IEnumerator RendererOffProcess()
        {
            yield return new WaitForSeconds(rendererOffDelay);
            GetComponent<MeshRenderer>().enabled = false;
        }

        private IEnumerator ResetProcess()
        {
            yield return new WaitForSeconds(resetDelay);

            GetComponent<MeshRenderer>().enabled = true;
            ResetPos();
        }
    }
}