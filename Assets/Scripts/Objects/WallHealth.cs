using UnityEngine;

namespace Objects
{
    public class WallHealth : HealthBehaviour
    {
        public AudioClip wallDeathClip;
        public Animator anim;
        public AudioSource wallAudioSource;
        public ParticleSystem hitParticles;

        private void Start()
        {
            // TODO replace enenmy sources
            anim = GetComponent <Animator> ();
            wallAudioSource = GetComponent <AudioSource> ();
            hitParticles = GetComponent <ParticleSystem> ();
        }

        protected override void Death(PlayerShooting attacker)
        {
            Debug.Log("removing:" + gameObject);
            Destroy (gameObject, 0f);
        }

        public override AudioSource GetAudioSource()
        {
            return wallAudioSource;
        }

        public override AudioClip GetDeathClip()
        {
            return wallDeathClip;
        }

        public override ParticleSystem GetHitParticles()
        {
            return hitParticles;
        }
    }
}