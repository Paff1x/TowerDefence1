using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

    [SerializeField] private LevelConfig _levelConfig;

    private List<ObjectGenerator> spawnPoints = new List<ObjectGenerator>();
    public int WaveCount { get; private set; }


    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        WaveCount = _levelConfig.waves.Length;
        GameManager.Instance.StartWaveEvent += StartWave;
    }
    private void StartWave()
    {
        StartCoroutine(StopRound(_levelConfig.waves[GameManager.Instance.CurrentWaveIndex].roundTime));
        InitCurrentWave(GameManager.Instance.CurrentWaveIndex);
    }
    
    IEnumerator StopRound(float time)
    {
        yield return new WaitForSeconds(time);
        foreach(ObjectGenerator _spawnPoint in spawnPoints)
        {
            Destroy(_spawnPoint.gameObject);
        }
        spawnPoints.Clear();

        yield return new WaitWhile(CheckEnemyCount);
        GameManager.Instance.NextWave();
    }

    private bool CheckEnemyCount()
    {
        if (GameManager.Instance.CurrentEnemyCount == 0)
            return false;
        else
            return true;

    }

    private void InitCurrentWave(int currentWaveIndex)
    {
        if (_levelConfig)
        {
            foreach (var spawnPointData in _levelConfig.waves[currentWaveIndex].spawnPointDatas)
            {
                InstantiateSpawnPoint(currentWaveIndex, spawnPointData.spawnPoint, spawnPointData.enemyPrefabs, spawnPointData.spawnTime);
            }
        }
    }

    private void InstantiateSpawnPoint(int currentWaveIndex, ObjectGenerator spawnPoint, GameObject[] enemyPrefabs, float spawnTime)
    {
        ObjectGenerator _spawnPoint = Instantiate(spawnPoint).GetComponent<ObjectGenerator>();
        _spawnPoint.Init(enemyPrefabs, spawnTime);
        spawnPoints.Add(_spawnPoint);
    }
}
