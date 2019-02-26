using UnityEngine;

namespace TMI
{
    public class StoneTmp : StoneBase
    {
        public override void Enter(StoneType type)
        {
            type = StoneType.None;
            //Debug.Log("노기능짱돌");
            base.Enter(type);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var hit = collision.collider.GetComponent<Hittable>();
            if (hit == null)
                return;

            ResetPos();

            hit.OnHit();
        }
    }
}