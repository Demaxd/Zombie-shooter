using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", _navMeshAgent.velocity.magnitude);
    }

}
