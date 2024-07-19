using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly float _delay = 2f;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _timeCounter;

    private void Update()
    {
        if (_timeCounter > 0)
            _timeCounter -= Time.deltaTime;

        Spawn();
    }

    private void Spawn()
    {
        if (_timeCounter > 0)
            return;

        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        _timeCounter = _delay;
    }
}