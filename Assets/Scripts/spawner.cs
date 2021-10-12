using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    Transform _transform;
    private Boolean _ready;
    private Boolean _endGame;
    private int _maxWaveCount = 10;
    private int _wave;

    private int _enemyFirstSpawnCount = 3;
    

    void Start()
    {
        _transform = GetComponent<Transform>();
        
    }

    private void Update()
    {
        //InvokeRepeating(nameof(Spawn), 0f, 1);
    }
    public void IsReady()
    {
        _ready = true;
        SummonWaves();
    }

    
    private void Spawn()
    {
        Instantiate(enemy, _transform.position + new Vector3(-2, 0, 0), Quaternion.identity);
    }

    public void SummonWaves()
    {
        if (_ready && _wave < _maxWaveCount && !_endGame)
        {
            for (int i = 0; i < _enemyFirstSpawnCount; i++)
            {
                Spawn();
            }

            _wave++;
            _enemyFirstSpawnCount += 3;
        }
    }

    public int GetWave()
    {
        return _wave;
    }

    public int GetMaxWave()
    {
        return _maxWaveCount;
    }

    public void SetEndGame(Boolean prmEndGameValue)
    {
        _endGame = prmEndGameValue;
    }
}