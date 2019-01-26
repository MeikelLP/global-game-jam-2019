using System;
using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class WallHealth : HealthBehavior
{
    public AudioClip wallDeathClip;
    public Animator anim;
    public AudioSource wallAudioSource;
    public ParticleSystem hitParticles;

    // Start is called before the first frame update
    void Start()
    {
        // TODO replace enenmy sources
        anim = GetComponent <Animator> ();
        wallAudioSource = GetComponent <AudioSource> ();
        hitParticles = GetComponent <ParticleSystem> ();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Death()
    {
//        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
//        GetComponent <Rigidbody> ().isKinematic = true;
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
