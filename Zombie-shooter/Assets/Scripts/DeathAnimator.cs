using UnityEngine;

public class DeathAnimator : MonoBehaviour
{
    private Animator _animator;
    private Character _character;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _character = GetComponent<Character>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        _character.Died += OnDie;
    }
    private void OnDisable()
    {
        _character.Died -= OnDie;
    }

    public void OnDie()
    {
        _animator.SetTrigger("onDie");
        _particleSystem.Play();
    }
}
