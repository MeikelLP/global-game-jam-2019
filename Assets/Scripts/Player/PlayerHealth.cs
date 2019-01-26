using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Objects;
using UnityEngine.SceneManagement;


public class PlayerHealth : HealthBehaviour
{

    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;

    // TODO replace enenmy sources
    private ParticleSystem hitParticles;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        healthSlider.value = 1;
        
        // TODO replace enenmy sources
        anim = GetComponent <Animator> ();

        hitParticles = GetComponent <ParticleSystem> ();
    }

    public void TakeDamage (PlayerShooting attacker, int damageAmount, Vector3 hitPoint)
    {
        base.TakeDamage(attacker, damageAmount, hitPoint);

        healthSlider.value = currentHealth / (float)startingHealth;
    }

    protected override void Death(PlayerShooting attacker)
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }

    public override AudioSource GetAudioSource()
    {
        return playerAudio;
    }

    public override AudioClip GetDeathClip()
    {
        return deathClip;
    }

    public override ParticleSystem GetHitParticles()
    {
        return hitParticles;
    }
}
