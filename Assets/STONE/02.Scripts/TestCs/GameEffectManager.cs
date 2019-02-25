using System.Collections;
using UnityEngine;
using System;

namespace TMI
{
    public class GameEffectManager : Singleton<GameEffectManager>
    {
        public Material[] mats;

        public event Action CompleteEffect = () => { };

        public Collider[] FindRangeObj(Collision cols, float radius)
        {
            var contactsPos = cols.contacts[0].point;
            var finds = Physics.OverlapSphere
                (
                    contactsPos,
                    radius,
                    1 << LayerMask.NameToLayer("hittable")
                    );

            return finds;
        }

        public IEnumerator DimementEffect(Transform tr)
        {
            var ps = tr.transform.GetChild(0).GetComponent<ParticleSystem>();
            ps.gameObject.SetActive(true);
            ps.Play();
            StoneBase.DeadEvent?.Invoke();

            var dissolves = tr.GetComponent<Renderer>();
            StartCoroutine(DeadMotion(dissolves, ps.gameObject));
            yield return null;
        }

        public IEnumerator LaserEffect(Transform tr)
        {
            var ps = tr.transform.GetChild(1).GetComponent<ParticleSystem>();
            ps.gameObject.SetActive(true);
            ps.Play();

            var dissolves = tr.GetComponent<Renderer>();
            StartCoroutine(DeadMotion(dissolves, ps.gameObject));
            yield return null;
        }

        private IEnumerator DeadMotion(Renderer renderer, GameObject ps)
        {
            string dissolveKey = "_Progress";
            float delay = UnityEngine.Random.Range(0.5f, 1.0f);
            yield return new WaitForSeconds(delay);
            float n = 1.0f;

            renderer.material = mats[1];
            for (; ; )
            {
                if (n <= 0.02f)
                {
                    renderer.material.SetFloat(dissolveKey, 0);
                    //ps.SetActive(false);
                    //오브젝트풀에 넣기
                    CompleteEffect();
                    yield break;
                }
                //yield return new WaitForSeconds(0.001f);

                n = Mathf.Lerp(n, 0, Time.deltaTime * 5);
                renderer.material.SetFloat(dissolveKey, n);
                yield return null;
            }
        }
    }
}