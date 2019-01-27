using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class StealingBehaviour : MonoBehaviour
{
    Animator anim;

    EnemyHealth enemyHealth;
    float timer;
    
    Behaviour closestStealable;
    private bool stealableInRange;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        closestStealable = EnemyTargetFinder.FindClosestStealable(enemyHealth.transform.position);
    }
    



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == closestStealable.gameObject)
        {
            stealableInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == closestStealable.gameObject)
        {
            stealableInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        // TODO steal
    }
}
