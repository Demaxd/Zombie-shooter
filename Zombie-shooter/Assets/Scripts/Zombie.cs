using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _spawner;
    private NavMeshAgent _navMeshAgent;
    private Player _player;


    private void Awake()
    {
        if (_spawner == null)_spawner = transform.parent.GetComponent<ZombieSpawner>();
        _player = _spawner.Player;
    }
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
        transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
    }
}
