using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class particleAttractorLinear : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] m_Particles;
    public Transform target;
    public float speed = 5f;
    private int numParticlesAlive;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (!GetComponent<Transform>())
        {
            GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (ps.isPlaying)
        {
            //if (Time.time > 3)
            {
                m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
                numParticlesAlive = ps.GetParticles(m_Particles);
                float step = Time.deltaTime;
                for (int i = 0; i < numParticlesAlive; i++)
                {
                    m_Particles[i].position =
                        Vector3.LerpUnclamped(m_Particles[i].position, target.position, step);
                }
                ps.SetParticles(m_Particles, numParticlesAlive);
            }
        }
    }
}