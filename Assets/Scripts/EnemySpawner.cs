using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float wavePause = 10;
    [SerializeField] private float spawnDelay = 5;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private AnimationCurve[] waves =
    {
        new AnimationCurve(
            new Keyframe(0, 1),
            new Keyframe(1, 2),
            new Keyframe(2, 3),
            new Keyframe(3, 4),
            new Keyframe(4, 5)
        ),
        new AnimationCurve(
            new Keyframe(0, 3),
            new Keyframe(1, 8),
            new Keyframe(2, 4),
            new Keyframe(3, 12),
            new Keyframe(4, 4),
            new Keyframe(5, 5)
        ),
    };
    
    public int CurrentWave { get; private set; }
    public int EnemiesAlive { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSpawning());
    }

    private IEnumerator WaitForSpawning()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (CurrentWave < waves.Length)
        {
            var currentCurve = waves[CurrentWave];

            foreach (var keyframe in currentCurve.keys)
            {
                for (int i = 0; i < (int)keyframe.value; i++)
                {
                    SpawnEnemy();
                }

                yield return new WaitUntil(() => EnemiesAlive <= (int)keyframe.value / 2);
            }
            yield return new WaitForSeconds(wavePause);
        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawning new enemy");
        var randomPosition = spawnPoints[(int)(Random.value * spawnPoints.Length)].position;
        var randomEnemy = enemyPrefabs[(int) (Random.value * enemyPrefabs.Length)];

        var go = Instantiate(randomEnemy, randomPosition, Quaternion.identity);
        var enemyBehaviour = go.GetComponent<EnemyHealth>();
        var agent = go.GetComponent<NavMeshAgent>();
        agent.Warp(randomPosition);
        enemyBehaviour.OnDeath += OnEnemyDeath;
        EnemiesAlive++;
    }

    private void OnEnemyDeath(object sender, EventArgs e)
    {
        EnemiesAlive--;
    }
}