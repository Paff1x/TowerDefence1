using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float timeBetweenWaves = 15f;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public Action StartWaveEvent;

    public static GameManager Instance { get; private set; }

    internal int CurrentEnemyCount =0;
    public int CurrentWaveIndex { get; private set; }
    public bool IsBattle { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartWave();
        var damagable = Base.Instance.GetComponent<Damagable>();
        damagable.DieEvent += OnBaseDead;
    }

    private void StartWave()
    {
        StartCoroutine(NextWaveDelay(timeBetweenWaves));
        GameUIController.Instance.ActivateTimerUntilNextWave(true, timeBetweenWaves);
        TowerChoicePanel.Instance.gameObject.SetActive(true);
        TowerChoicePanel.Instance.RollTowers();
        IsBattle = false;
    }
    IEnumerator NextWaveDelay(float time)
    {
        yield return new WaitForSeconds(time);
        StartWaveEvent();
        GameUIController.Instance.ActivateTimerUntilNextWave(false, 0);
        TowerChoicePanel.Instance.gameObject.SetActive(false);
        IsBattle = true;
        GameUIController.Instance.ShowCurrentWaveIndex(CurrentWaveIndex);
    }
    private void OnBaseDead(Damagable damagable)
    {
        losePanel.SetActive(true);
    }

    public void NextWave()
    {
        if (CurrentWaveIndex < LevelController.Instance.WaveCount-1)
        {
            CurrentWaveIndex++;
            StartWave();
        }
        else
        {
            winPanel.SetActive(true);
        }
    }
}
