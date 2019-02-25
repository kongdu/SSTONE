using HTC.UnityPlugin.Vive;
using UnityEngine;

namespace TMI
{
    public enum WeaponState { IDLE, LOAD, ATTACK }

    //1. 발사 이벤트 방향벡터 구함구하고 갱신.
    public class Weapon : MonoBehaviour
    {
        public Transform pivot;

        public SpringJoint joint;

        public StoneBase projectile;

        [SerializeField]
        private WeaponState state = WeaponState.IDLE;

        public WeaponState State
        {
            get => state;

            set => state = value;
        }

        private void OnEnable()
        {
            //돌 선택됫을떄 이벤트 연결.
            RightController.ControllerPressDown += StoneLoad;
        }

        private void StoneLoad()
        {
            SlingReady();

            projectile = new Base<StoneBase>().StoneFindObj();
            projectile.gameObject.SetActive(true);

            var rid = projectile.GetComponent<Rigidbody>();
            rid.useGravity = false;
            rid.constraints = RigidbodyConstraints.None;

            projectile.stoneInfo.dir = Vector3.zero;
            projectile.stoneInfo.power = 0.0f;
        }

        private void SlingReload()
        {
            var pose = VivePose.GetPose(HandRole.RightHand);
            projectile.transform.position = pose.pos;
            // Debug.Log("장전");
            StateChange(WeaponState.LOAD);

            var slingres = CalcDirNPower(projectile.transform.position, joint.transform.position);
            if (slingres.Item2 <= 0.2f)
            {
                joint.massScale = 0;
                var projectiletest = CalcDirNPower
                    (pivot.position, projectile.transform.position);

                var rot = Quaternion.LookRotation(projectiletest.Item1);

                joint.transform.rotation = Quaternion.Euler(Vector3.zero);
                joint.transform.position = projectile.transform.position -
                    projectile.transform.forward * (projectile.transform.lossyScale.z * 0.5f);

                projectile.transform.rotation = rot;
            }
            else
            {
                joint.massScale = 1;
                var res = CalcDirNPower(Vector3.zero, Vector3.zero);
                Directioncalculation(res);
            }

            RightController.ControllerPressUp += StateAttack;
        }

        public (Vector3, float) CalcDirNPower(Vector3 pos1, Vector3 pos2)
        {
            var dir = pos1 - pos2;
            var power = dir.magnitude;
            dir.Normalize();
            return (dir, power);
        }

        public void Directioncalculation((Vector3 dir, float power) info)
        {
            projectile.stoneInfo.dir = info.dir;
            projectile.stoneInfo.power = info.power;
        }

        /// <summary>
        /// 돌이 선택됬을때 호출
        /// </summary>
        // 이벤트로 연결해놓고 돌이 선택되면 실행시킴.
        public void SlingReady()
        {
            //Debug.Log("준비");

            StateChange(WeaponState.IDLE);

            RightController.ControllerPress += SlingReload;
        }

        private void StateChange(WeaponState state)
        {
            this.state = state;
        }

        private void StateAttack()
        {
            var res = CalcDirNPower(pivot.position, projectile.transform.position);
            Directioncalculation(res);

            joint.massScale = 1.0f;

            //Debug.Log("공격");
            StateChange(WeaponState.ATTACK);
            projectile.Enter(StoneBase.type);
            Debug.Log(StoneBase.type);

            RightController.ControllerPressUp -= StateAttack;
            RightController.ControllerPress -= SlingReload;
        }
    }
}