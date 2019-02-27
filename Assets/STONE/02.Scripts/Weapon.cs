using System.Collections;
using HTC.UnityPlugin.Vive;
using UnityEngine;

namespace TMI
{
    public enum WeaponState { IDLE, LOAD, ATTACK }

    // 1. 발사 이벤트 방향벡터 구하고 갱신
    public class Weapon : MonoBehaviour
    {
        public Transform pivot;
        public SpringJoint joint;

        [Tooltip("확인용으로 일단 퍼블릭")]
        public StoneBase selectedStone;

        public float power = 10f;

        private Transform rightTr;

        [SerializeField]
        private WeaponState state = WeaponState.IDLE;

        private StoneSelectUI stoneSelectUI;

        public WeaponState State
        {
            get => state;
            set => state = value;
        }

        private void OnEnable()
        {
            rightTr = FindObjectOfType<RightController>().transform;
            stoneSelectUI = FindObjectOfType<StoneSelectUI>();
        }

        public void StoneLoad()
        {
            State = WeaponState.IDLE;
            StoneSelectUI stoneSelectUI = FindObjectOfType<StoneSelectUI>();
            selectedStone = FindObjectOfType<StoneSelectUI>().SelectedStone;

            RightController.ControllerPress += SlingReload;
            RightController.ControllerPressUp += StateAttack;
        }

        private void SlingReload()
        {
            State = WeaponState.LOAD;

            selectedStone.transform.position = joint.transform.position;
        }

        public void StateAttack()
        {
            State = WeaponState.ATTACK;

            var res = CalcDirNPower(pivot.position, joint.transform.position);
            selectedStone.stoneInfo = new StoneInfo(res.dir, res.power);
            selectedStone.Shot();

            // StartCoroutine(LaserShot());
            RightController.ControllerPress -= SlingReload;
            RightController.ControllerPressUp -= StateAttack;
        }

        public (Vector3 dir, float power) CalcDirNPower(Vector3 pos1, Vector3 pos2)
        {
            var dir = pos1 - pos2;
            var power = dir.magnitude * this.power;
            dir.Normalize();
            return (dir, power);
        }

        private IEnumerator LaserShot()
        {
            yield return new WaitForSeconds(0.3f);
            stoneSelectUI.MoveNext();
        }
    }
}