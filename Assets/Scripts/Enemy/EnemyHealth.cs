using System;
using Objects;
using UnityEngine;

public class EnemyHealth : HealthBehaviour
{
    public int money = 10;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    bool isDead;
    bool isSinking;

    public static event EventHandler<EnemyDeathEventArgs> OnDeathAny;
    public event EventHandler<EnemyDeathEventArgs> OnDeath;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }

    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (PlayerShooting attacker, int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play ();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death (attacker);
        }
    }

    protected override void Death (PlayerShooting attacker)
    {
        isDead = true;
        var eventArgs = new EnemyDeathEventArgs{Enemy = this, Killer = attacker};
        OnDeath?.Invoke(this, eventArgs);
        OnDeathAny?.Invoke(this, null);

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        StartSinking();
    }


    void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }

    public override AudioSource GetAudioSource()
    {
        return enemyAudio;
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
