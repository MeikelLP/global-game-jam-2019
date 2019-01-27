using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Enemy;
using UnityEngine;

public class StealingBehaviour : MonoBehaviour
{
    Animator anim;

    EnemyHealth enemyHealth;
    float timer;
    
    Behaviour closestStealable;
    private bool stealableInRange;
    public bool hasStealed = false;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (hasStealed)
        {
            return;
        }
        closestStealable = EnemyTargetFinder.FindClosestStealable(enemyHealth.transform.position);

        if (stealableInRange)
        {
            closestStealable.gameObject.SetActive(false);
            hasStealed = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasStealed)
        {
            return;
        }

        if (other.gameObject == closestStealable.gameObject)
        {
            stealableInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (hasStealed)
        {
            return;
        }
        if (other.gameObject == closestStealable.gameObject)
        {
            stealableInRange = false;
        }
    }
}
