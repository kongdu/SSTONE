using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class DeadEffecter : MonoBehaviour
    {
        public event Action CompleteEffect = () => { };

        private ParticleSystem ps;
        private Renderer renderer;

        private void Awake()
        {
            ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            renderer = GetComponent<Renderer>();
        }

        public IEnumerator DimementEffect()
        {
            ps.gameObject.SetActive(true);
            ps.Play();
            StoneBase.DeadEvent?.Invoke();
            StartCoroutine(DeadMotion(ps.gameObject));
            yield return null;
        }

        public void PlayDead()
        {
            StartCoroutine(DeadMotion(ps.gameObject));
        }

        private IEnumerator DeadMotion(GameObject ps)
        {
            string dissolveKey = "_Progress";
            float delay = UnityEngine.Random.Range(0.5f, 1.0f);
            yield return new WaitForSeconds(delay);
            float n = 1.0f;

            renderer.material = GameEffectManager.Instance.mats[1];
            for (; ; )
            {
                if (n <= 0.02f)
                {
                    renderer.material.SetFloat(dissolveKey, 0);
                    //ps.SetActive(false);
                    //오브젝트풀에 넣기
                    CompleteEffect();
                    n = 1;
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