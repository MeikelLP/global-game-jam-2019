using UnityEngine;
using System.Collections;
using Objects;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
//        var deltaTime = Time.deltaTime;
//        if (enemyHealth.currentHealth > 0)
//        {
//            nav.destination = player.position;
//        }
    }

    void FixedUpdate()
    {
        HealthBehavior closestEnemy = FindClosestEnemy();

        nav.destination = closestEnemy.transform.position;
    }


    private HealthBehavior FindClosestEnemy()
    {
        var gos = GameObject.FindObjectsOfType<HealthBehavior>();
        // TODO remove enemies

        HealthBehavior closest = null;
        float minimumDistance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (HealthBehavior go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < minimumDistance)
            {
                closest = go;
                minimumDistance = curDistance;
            }
        }

        return closest;
    }
}