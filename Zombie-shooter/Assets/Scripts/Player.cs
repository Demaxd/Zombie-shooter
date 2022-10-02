using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            direction.z = 1f;
        if (Input.GetKey(KeyCode.S))
            direction.z = -1f;
        if (Input.GetKey(KeyCode.A))
            direction.x = -1f;
        if (Input.GetKey(KeyCode.D))
            direction.x = 1f;
        _navMeshAgent.velocity = direction.normalized * _moveSpeed;
    }
}
