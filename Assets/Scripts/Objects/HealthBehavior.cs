using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public abstract class HealthBehavior : MonoBehaviour
    {
        public int startingHealth = 100;
        public int currentHealth;
        public Slider healthSlider;
        public Image damageImage;
      
        //public float flashSpeed = 5f;
        //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

        public void TakeDamage (PlayerShooting attacker, int damageAmount, Vector3 hitPoint)
        {
            Debug.Log("calling takedamage");
            // TODO GetAudioSource().Play ();

            currentHealth -= damageAmount;
            Debug.Log("new health amount: " + currentHealth);
            
            //TODO GetHitParticles().transform.position = hitPoint;
            //TODO GetHitParticles().Play();

            if(currentHealth <= 0)
            {
                Death();
            }
        }

        public abstract void Death();
        
        public abstract AudioSource GetAudioSource();
        public abstract AudioClip GetDeathClip();
        public abstract ParticleSystem GetHitParticles();
    }
    
    
}