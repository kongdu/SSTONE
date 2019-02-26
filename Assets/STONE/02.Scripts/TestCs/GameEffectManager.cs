using System.Collections;
using UnityEngine;

namespace TMI
{
    public class GameEffectManager : Singleton<GameEffectManager>
    {
        public Material[] mats;

        public Collider[] FindRangeObj(Collision cols, float radius)
        {
            var contactsPos = cols.contacts[0].point;
            return Physics.OverlapSphere(contactsPos, radius, LayerMask.GetMask("Hittable"));
        }

        public IEnumerator LaserEffect(Transform tr)
        {
            var ps = tr.transform.GetChild(1).GetComponent<ParticleSystem>();
            ps.gameObject.SetActive(true);
            ps.Play();

            var dissolves = tr.GetComponent<Renderer>();
            //StartCoroutine(DeadMotion(dissolves, ps.gameObject));
            yield return null;
        }
    }
}