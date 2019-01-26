using Objects;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
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
            if (enemyHealth.currentHealth <= 0)
            {
                return;
            }

            var closestEnemy = FindClosestEnemy();
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
                // remove self
                if (go is EnemyHealth)
                {
                    continue;
                }
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
}