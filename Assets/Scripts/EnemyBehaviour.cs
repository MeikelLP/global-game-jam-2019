using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private float range = 1;
    [SerializeField] private float damage = 20;
    [SerializeField] private int attacksPerMinute = 40;

    public bool IsAttacking;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = PlayerBehaviour.Instance.transform.position;

        var distance = Vector3.Distance(_agent.destination, transform.position);
        if (distance <= range)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (!IsAttacking)
        {
            StartCoroutine(WaitAfterAttack());   
        }
    }

    private IEnumerator WaitAfterAttack()
    {
        IsAttacking = true;
        
        PlayerBehaviour.Instance.ApplyDamage(damage);
        yield return new WaitForSeconds(attacksPerMinute / 60f);
        
        IsAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
