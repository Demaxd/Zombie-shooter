using UnityEngine;
using UnityEngine.AI;

public class MovementAnimator : MonoBehaviour
{
    private Character _character;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void OnEnable()
    {
        _character.Died += OnDie;
    }

    private void OnDisable()
    {
         _character.Died -= OnDie;
    }

    private void Update()
    {
        _animator.SetFloat("speed", _navMeshAgent.velocity.magnitude);
    }

    private void OnDie()
    {
        _navMeshAgent.isStopped = true;
        enabled = false;
    }

}
