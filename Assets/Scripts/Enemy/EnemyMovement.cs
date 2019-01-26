using UnityEngine;
using System.Collections;
using Objects;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private NavMeshAgent nav;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        HealthBehaviour closestEnemy = FindClosestEnemy();

        nav.destination = closestEnemy.transform.position;
    }


    private HealthBehaviour FindClosestEnemy()
    {
        var gos = GameObject.FindObjectsOfType<HealthBehaviour>();
        // TODO remove enemies

        HealthBehaviour closest = null;
        float minimumDistance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (HealthBehaviour go in gos)
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