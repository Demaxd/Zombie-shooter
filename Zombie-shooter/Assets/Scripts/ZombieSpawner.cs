using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private Player _player;

    public Player Player => _player;


    private void Start()
    {
        Instantiate(_zombiePrefab, transform);
    }

}
