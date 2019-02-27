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
        public GameObject stoneSelect;

        [Tooltip("확인용으로 일단 퍼블릭")]
        public StoneBase projectile;

        public float power = 3f;

        private Transform rightTr;

        [SerializeField]
        private WeaponState state = WeaponState.IDLE;

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
            State = WeaponState.IDLE;

            stoneSelect = FindObjectOfType<StoneSelectUI>().SelectedStone;
            projectile = stoneSelect.GetComponent<StoneBase>();

            RightController.ControllerPress += SlingReload;
        }

        private void SlingReload()
        {
            State = WeaponState.LOAD;
            RightController.ControllerPressUp += StateAttack;

            var pose = VivePose.GetPoseEx(HandRole.RightHand, rightTr.transform);
            stoneSelect.transform.position = pose.pos;
            // Debug.Log("장전");

            var slingres = CalcDirNPower(stoneSelect.transform.position, joint.transform.position);
            if (slingres.power <= 0.2f)
            {
                var res = CalcDirNPower(pivot.position, projectile.transform.position);
                projectile.stoneInfo = new StoneInfo(res.dir, res.power);

                joint.tolerance = 3f;
                joint.transform.LookAt(stoneSelect.transform);
                joint.transform.rotation = Quaternion.Euler(Vector3.zero);
                joint.transform.position = pose.pos;
            }
            else
            {
                projectile.rb.constraints = RigidbodyConstraints.None;

                joint.tolerance = 0.02f;

                //RightController.ControllerPressUp -= StateAttack;
            }
        }

        public void StateAttack()
        {
            State = WeaponState.ATTACK;
            RightController.ControllerPressUp -= StateAttack;

            projectile.GetComponent<Collider>().enabled = true;
            projectile.Shot();

            joint.tolerance = 0.02f;

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
    }
}