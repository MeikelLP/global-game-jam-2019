using System;
using Objects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Enemy
{
    public class EnemyTargetFinder
    {
        /**
         * Return the closest HealthBehaviour object that is not HealthBehaviour
         */
        public static Behaviour FindClosestEnemy(Vector3 fromPosition)
        {
            return FindClosest<HealthBehaviour>(fromPosition);

        }

        public static Behaviour FindClosest<T>(Vector3 position) where T : Behaviour
        {
            var gos = GameObject.FindObjectsOfType<T>();

            Behaviour closest = null;
            float minimumDistance = Mathf.Infinity;
            foreach (T go in gos)
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