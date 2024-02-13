using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    public Transform[] _spawnPlace;                                                        
    
    private GameObject _enemy;
    private int _spawnRandomPlace;
    private float _angleRandom;

    void Start()
    {
        _spawnPlace = GetComponentsInChildren<Transform>();                                
    }
    void Update()
    {
        EnemySpawn();
    }
    private void EnemySpawn()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(_enemyPrefab);
            _spawnRandomPlace = Random.Range(1, _spawnPlace.Length - 1);
            _enemy.transform.position = _spawnPlace[_spawnRandomPlace].transform.position;
            _angleRandom = Random.Range(0, 360);
            _enemy.transform.Rotate(0, _angleRandom, 0);
        }
    }
}
