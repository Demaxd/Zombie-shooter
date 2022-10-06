using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : Character
{
    [SerializeField] private Cursor _cursor;
    [SerializeField] private float _moveSpeed;

    private Gun _gun;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {

        _gun = GetComponentInChildren<Gun>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        InputHandle();
    }

    private void InputHandle()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection.z = 1f;
        if (Input.GetKey(KeyCode.S))
            moveDirection.z = -1f;
        if (Input.GetKey(KeyCode.A))
            moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.D))
            moveDirection.x = 1f;

        _navMeshAgent.velocity = moveDirection.normalized * _moveSpeed;

        Vector3 forward = (_cursor.transform.position - transform.position).normalized;
        Vector3 lookDirection = new Vector3(forward.x, 0, forward.z);
        transform.rotation = Quaternion.LookRotation(lookDirection);


        if (Input.GetMouseButtonDown(0))
        {
            _gun.Shoot(forward);
        }
            

    }

}
