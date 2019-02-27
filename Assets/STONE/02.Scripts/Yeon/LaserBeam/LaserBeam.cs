using System.Collections;
using UnityEngine;

namespace TMI
{
    public class LaserBeam : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject beamStart;

        public GameObject beamCube;
        public GameObject beamEnd;

        [Header("Adjustable Variables")]
        public float waitingTime = 1f;

        public float beamBeginOffset = 1f;
        public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
        public float beamMaxDistance = 150f; //레이저 빔 최대 길이 (맵 가로세로가 100 대각선이 150)
        public float laserBeamHitRadius = 3f;
        public float textureLengthScale = 3; //Length of the beam texture

        public float cleanerBeamRadius = 3f;

        private void Awake()
        {
            beamStart = Instantiate(beamStart, transform.position, transform.rotation) as GameObject;
            beamCube = Instantiate(beamCube, transform.position, transform.rotation) as GameObject;
            beamEnd = Instantiate(beamEnd, transform.position, transform.rotation) as GameObject;

            prefabActiveSwitch(false);
        }

        /*
        private void OnEnable()
        {
            ViveController.OnPressDownTrigger_RightHand += ShootLaserBeam;
        }

        private void OnDisable()
        {
            ViveController.OnPressDownTrigger_RightHand -= ShootLaserBeam;
        }
        */

        public void Shot(Vector3 dir)
        {
            SettingLaserBeam(transform.position, dir);
            SettingVaccume(transform.position, dir);
            SphereCast(dir);

            StopAllCoroutines();
            StartCoroutine(BlinkProcess());
        }

        private void SphereCast(Vector3 dir)
        {
            var hits = Physics.SphereCastAll(beamStart.transform.position, cleanerBeamRadius, dir * beamMaxDistance, LayerMask.GetMask("Hittable"));

            foreach (var item in hits)
            {
                var hit = item.transform.GetComponent<Hittable>();

                hit?.OnHit();
            }
        }

        /// <summary>
        /// 시작점과 이어지는 끝점 찾기 (레이캐스트 활용)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        private Vector3 FindEndPoint(Vector3 start, Vector3 dir)
        {
            Vector3 end = Vector3.zero;

            if (Physics.Raycast(start, dir, out RaycastHit hit, beamMaxDistance, LayerMask.GetMask("BeamEffectHittable")))
                end = hit.point - (dir.normalized * beamEndOffset);
            else
                end = start + (dir * beamMaxDistance);

            return end;
        }

        /// <summary>
        ///  레이저빔 데이터 세팅하기 (시작점과 끝점 구해서 위치와 스케일 세팅하기)
        /// </summary>
        /// <param name="start">시작점</param>
        /// <param name="dir">끝점</param>
        private void SettingLaserBeam(Vector3 start, Vector3 dir)
        {
            Vector3 end = FindEndPoint(start, dir);
            float distance = Vector3.Distance(start, end);

            // 위치
            beamStart.transform.position = start;
            beamCube.transform.position = start;
            beamEnd.transform.position = end;

            // 방향
            beamStart.transform.LookAt(beamEnd.transform.position);
            beamCube.transform.LookAt(beamEnd.transform.position);
            beamEnd.transform.LookAt(beamStart.transform.position);

            // 크기
            Vector3 beamScale = beamCube.transform.localScale;
            beamScale.z = distance;
            beamCube.transform.localScale = beamScale;
        }

        /// <summary>
        /// 레이저 반경을 지나가는 청소기 데이터 세팅
        /// (청소기가 지나가면서 부딪히는 적에게 데미지 줄 예정)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dir"></param>
        private void SettingVaccume(Vector3 start, Vector3 dir)
        {
            Vector3 end = FindEndPoint(start, dir);
            float distance = Vector3.Distance(start, end);

            // 크기
            Vector3 beamScale = beamCube.transform.localScale;
            beamScale.z = distance;
            beamCube.transform.localScale = beamScale;
        }

        /// <summary>
        /// 레이저빔 깜빡 켜졌다 없어지기
        /// </summary>
        /// <returns></returns>
        private IEnumerator BlinkProcess()
        {
            prefabActiveSwitch(true);
            yield return new WaitForSeconds(waitingTime);
            prefabActiveSwitch(false);
        }

        /// <summary>
        /// 레이저빔 관련 프리팹 모두 켜거나 끄거나
        /// </summary>
        /// <param name="ON">True or False</param>
        private void prefabActiveSwitch(bool ON)
        {
            if (ON)
            {
                beamStart.SetActive(true);
                beamCube.SetActive(true);
                beamEnd.SetActive(true);
            }
            else
            {
                beamStart.SetActive(false);
                beamCube.SetActive(false);
                beamEnd.SetActive(false);
            }
        }
    }
}