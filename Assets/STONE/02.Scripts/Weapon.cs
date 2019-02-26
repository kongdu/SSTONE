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

        private Transform rightTr;

        public GameObject stoneSelect;

        public WeaponState State
        {
            get => state;

            set => state = value;
        }

        private void OnEnable()
        {
            rightTr = FindObjectOfType<RightController>().transform;
        }

        public void StoneLoad()
        {
            StateChange(WeaponState.IDLE);
            stoneSelect = FindObjectOfType<StoneSelectUI>().SelectedStone;
            projectile = stoneSelect.GetComponent<StoneBase>();

            RightController.ControllerPress += SlingReload;
        }

        private void SlingReload()
        {
            StateChange(WeaponState.LOAD);
            var pose = VivePose.GetPoseEx(HandRole.RightHand, rightTr.transform);
            stoneSelect.transform.position = pose.pos;
            // Debug.Log("장전");

            var slingres = CalcDirNPower(stoneSelect.transform.position, joint.transform.position);
            if (slingres.Item2 <= 0.2f)
            {
                joint.tolerance = 3;

                var res = CalcDirNPower(pivot.position, projectile.transform.position);
                Directioncalculation(res);

                joint.transform.LookAt(stoneSelect.transform);

                joint.transform.rotation = Quaternion.Euler(Vector3.zero);

                joint.transform.position = pose.pos;

                RightController.ControllerPressUp += StateAttack;
            }
            else
            {
                joint.tolerance = 0.02f;
                projectile.rid.constraints = RigidbodyConstraints.None;
                RightController.ControllerPressUp -= StateAttack;
            }
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
            projectile.stoneInfo = new StoneInfo(info.dir, info.power);
            //projectile.stoneInfo.dir = info.dir;
            //projectile.stoneInfo.power = info.power;
        }

        private void StateChange(WeaponState state)
        {
            this.state = state;
        }

        public void StateAttack()
        {
            StateChange(WeaponState.ATTACK);
            projectile.GetComponent<Collider>().enabled = true;

            joint.tolerance = 0.02f;

            projectile.Enter(StoneBase.type);

            RightController.ControllerPress -= SlingReload;
            RightController.ControllerPressUp -= StateAttack;
        }
    }
}