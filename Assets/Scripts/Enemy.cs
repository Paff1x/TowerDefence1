using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;


    private NavMeshAgent _navAgent;

    private void OnEnable()
    {
        GameManager.Instance.CurrentEnemyCount++;
    }
    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.SetDestination(Base.Instance.transform.position);
        _navAgent.speed = _moveSpeed;
    }
    private void OnDisable()
    {
        GameManager.Instance.CurrentEnemyCount--;
    }
}
