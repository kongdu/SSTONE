using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class DeadEffecter : MonoBehaviour
    {
        public event Action CompleteEffect = () => { };

        public ParticleSystem particleSystem;
        private new Renderer renderer;
        private AudioSource deadSound;

        private void Awake()
        {
            particleSystem = transform.GetChild(2).GetComponent<ParticleSystem>();
            renderer = GetComponent<Renderer>();
            deadSound = GetComponent<AudioSource>();
        }

        public IEnumerator DimementEffect()
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
            StoneBase.DeadEvent?.Invoke();
            StartCoroutine(DeadMotion(particleSystem.gameObject));
            yield return null;
        }

        public void PlayDead()
        {
            StartCoroutine(DeadMotion(particleSystem.gameObject));
            //DeadMotion();
        }

        private void DeadMotion()
        {
            //particleSystem.gameObject.SetActive(true);
            CompleteEffect();
            Debug.Log("파티클실행");
        }

        private IEnumerator DeadMotion(GameObject ps)
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
            deadSound.Play();
            //string dissolveKey = "_Progress";
            //float delay = UnityEngine.Random.Range(0.5f, 1.0f);
            renderer.enabled = false;
            yield return new WaitForSeconds(1f);

            CompleteEffect();

            //float n = 1.0f;

            //renderer.material = GameEffectManager.Instance.mats[1];
            //for (; ; )
            //{
            //    if (n <= 0.02f)
            //    {
            //        renderer.material.SetFloat(dissolveKey, 0);
            //        //ps.SetActive(false);
            //        //오브젝트풀에 넣기
            //        n = 1;
            //        yield break;
            //    }
            //    //yield return new WaitForSeconds(0.001f);

            //    n = Mathf.Lerp(n, 0, Time.deltaTime * 5);
            //    renderer.material.SetFloat(dissolveKey, n);
            //    yield return null;
            //}
        }
    }
}