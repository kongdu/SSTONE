using UnityEngine;

namespace TMI
{
    public class Dimement : StoneBase
    {
        private float radius = 2.0f;

        public override void Shot()
        {
            base.Shot();

            //Debug.Log("Dimement");
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("hit");
            var hit = collision.collider.GetComponent<Hittable>();
            if (hit == null)
                return;

            ResetPos();
            var findobjs = GameEffectManager.Instance.FindRangeObj(collision, radius);

            foreach (var item in findobjs)
            {
                var mob = item.GetComponent<Hittable>();
                mob.OnHit();
            }
        }
    }
}