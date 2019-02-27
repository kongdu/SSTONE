using UnityEngine;

namespace TMI
{
    public class StoneTmp : StoneBase
    {
        public override void Shot()
        {
            //Debug.Log("노기능짱돌");
            base.Shot();
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