using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Extraction : MonoBehaviour
    {
        private ParticleSystem[] particles;

        private List<ParticleSystem> pslist;
        private float minSize;
        private float maxSize;

        private Transform playertarget;
        //test

        public static int recoveryValue = 0;

        private void OnEnable()
        {
            //Test
            StoneBase.DeadEvent += MonsterDeadComplate;
        }

        private void OnDisable()
        {
            StoneBase.DeadEvent -= MonsterDeadComplate;
        }

        private void Awake()
        {
            particles = GetComponentsInChildren<ParticleSystem>();
            pslist = new List<ParticleSystem>(particles);
            foreach (var item in particles) item.Stop();
        }

        //Test
        public void MonsterDeadComplate()
        {
            StartCoroutine(RecoveryStone());
        }

        private IEnumerator RecoveryStone()
        {
            yield return new WaitForSeconds(5.5f);
            recoveryValue += 1;

            minSize += 0.1f;
            maxSize += 0.1f;

            Debug.Log("회복치 = " + recoveryValue);

            var PsMain0 = particles[0].main;
            var PsMain1 = particles[1].main;
            PsMain0.startSize = new ParticleSystem.MinMaxCurve(minSize * 0.5f, maxSize * 0.5f);
            PsMain1.startSize = new ParticleSystem.MinMaxCurve(minSize, maxSize);

            var psMain2 = particles[2].main;
            psMain2.startSize = new ParticleSystem.MinMaxCurve(recoveryValue * 0.3f, recoveryValue * 0.3f);

            foreach (var item in particles)
            {
                item.Play();
            }

            yield return new WaitForSeconds(2.0f);
            var player = FindObjectOfType<Player>();
            player.Hp += (recoveryValue);
            recoveryValue = 0;

            foreach (var item in particles)
            {
                item.Stop();
            }

            yield return null;
        }
    }
}