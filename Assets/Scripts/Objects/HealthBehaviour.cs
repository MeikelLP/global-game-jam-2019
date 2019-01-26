using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public abstract class HealthBehaviour : MonoBehaviour
    {
        public int startingHealth = 100;
        public int currentHealth;
        public Slider healthSlider;
        public Image damageImage;

        public void TakeDamage (PlayerShooting attacker, int damageAmount, Vector3 hitPoint)
        {
            GetAudioSource().Play ();

            currentHealth -= damageAmount;
            Debug.Log("new health amount: " + currentHealth);
            
            //TODO GetHitParticles().transform.position = hitPoint;
            //TODO GetHitParticles().Play();

            if(currentHealth <= 0)
            {
                Death(attacker);
            }
        }

        protected abstract void Death(PlayerShooting attacker);
        
        public abstract AudioSource GetAudioSource();
        public abstract AudioClip GetDeathClip();
        public abstract ParticleSystem GetHitParticles();
    }
    
    
}