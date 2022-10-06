using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : Character
{
    [SerializeField] private ZombieSpawner _spawner;
    private NavMeshAgent _navMeshAgent;
    private Player _player;

    private bool _isDead = false;



    private void Awake()
    {
        if (_spawner == null)  _spawner = transform.parent.GetComponent<ZombieSpawner>();
        _player = _spawner.Player;


        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
    }

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(_player.transform.position - transform.position);
    }

    private void Update()
    {
        if (_isDead) return;

        _navMeshAgent.SetDestination(_player.transform.position);
        transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
    }

    public void TryDie()
    {
        if (!_isDead)
        {
            Die();
            _isDead = true;
        }
    }
}
