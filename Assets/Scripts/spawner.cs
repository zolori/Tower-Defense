using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gobelin;
    Transform _transform;
    private bool _ready;
    private bool _endGame;
    private int _maxWaveCount = 10;
    private int _wave;

    private int _enemyFirstSpawnCount = 3;


    void Start()
    {
        _transform = GetComponent<Transform>();
        GameManager.instance.CheckLevelHeight();
    }

    public void IsReady()
    {
        _ready = true;
        SummonWaves();
    }


    private void Spawn()
    {
        int r = Random.Range(0,101);

        if (r < 20)
            Instantiate(gobelin, _transform.position + new Vector3(-2, 0, 0), _transform.rotation);
        else
            Instantiate(enemy, _transform.position + new Vector3(-2, 0, 0), _transform.rotation);
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

    public void SetEndGame(bool prmEndGameValue)
    {
        _endGame = prmEndGameValue;
    }
}