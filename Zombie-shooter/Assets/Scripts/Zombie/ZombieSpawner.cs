using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Pool
{
    [Header("References")]
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private Player _player;

    [Header("Options")]
    [SerializeField] private int _secondsBetweenSpawn;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private int _countPerPoint = 1;
    public Player Player => _player;


    private void Start()
    {
        FillPool(_zombiePrefab.gameObject);
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            SpawnZombies(_countPerPoint);
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }

    }

    private void SpawnZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (TryGetObject(out GameObject zombie))
            {
                Vector3 spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
                zombie.transform.position = spawnPos;
                zombie.SetActive(true);
            }
        }

    }

}
