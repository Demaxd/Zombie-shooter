using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollisionHandler : MonoBehaviour
{
    private Zombie _zombie;

    private void Awake()
    {
        _zombie = GetComponent<Zombie>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
            _zombie.TryDie();
    }
}
