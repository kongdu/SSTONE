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
        public float shotDelay = 0.1f;

        private LaserBeam laserBeam;
        private StoneSelectUI stoneSelectUI;

        protected override void Awake()
        {
            base.Awake();
            laserBeam = GetComponent<LaserBeam>();
            stoneSelectUI = FindObjectOfType<StoneSelectUI>();
        }

        public override void Shot()
        {
            Debug.Log("Shot - DIR : " + stoneInfo.dir + "    POWER : " + stoneInfo.power);

            StopAllCoroutines();
            StartCoroutine(ShotProcess());
        }

        private IEnumerator ShotProcess()
        {
            rb.AddForce(stoneInfo.dir * stoneInfo.power, ForceMode.Impulse);

            yield return new WaitForSeconds(shotDelay);

            GetComponent<MeshRenderer>().enabled = false;
            laserBeam.Shot(stoneInfo.dir);
            ResetInfo();

            stoneSelectUI.MoveNext();
            yield return new WaitForSeconds(resetDelay);

            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}