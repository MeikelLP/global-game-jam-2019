﻿using System;
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

        public EnemyPriority enemyPriority;

        private StealingBehaviour stealingBehaviour;

        private GameObject exit = null;

        public float despawnDistance = 2f;

        void Awake()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<NavMeshAgent>();
            stealingBehaviour = GetComponent<StealingBehaviour>();
        }

        void FixedUpdate()
        {
            if (enemyHealth.currentHealth <= 0)
            {
                return;
            }

            Transform closestTarget; 
            switch (enemyPriority)
            {
                case EnemyPriority.STEALABLE:
                    if (stealingBehaviour.hasStealed)
                    {
                        if (exit == null)
                        {
                            exit = GameObject.Find("Spawn");
                        }
                        
                        closestTarget = exit.transform;

                        Despawn();
                    }
                    else
                    {
                        closestTarget = EnemyTargetFinder.FindClosestStealable(transform.position).transform;
                    }
                    break;
                case EnemyPriority.PLAYER:
                default:
                    closestTarget = EnemyTargetFinder.FindClosestEnemy(transform.position).transform;
                    break;
            }

            nav.destination = closestTarget.position;
        }

        private void Despawn()
        {
            var distance = Vector3.Distance(transform.position, exit.transform.position);
            if (distance < despawnDistance)
            {
                GetComponent<EnemyHealth>().Die();
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(nav.destination, 0.5f);
            }
        }
    }
}