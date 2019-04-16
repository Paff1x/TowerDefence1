using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{

    [SerializeField] private Text timeUntilNextWaveText;
    [SerializeField] private Text currentWaveText;

    public static GameUIController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void OnShowTowerChoicePanelButtonClick()
    {
        if (!GameManager.Instance.IsBattle)
            TowerChoicePanel.Instance.gameObject.SetActive(true);
    }
    public void OnCloseTowerChoicePanelButtonClick()
    {
        TowerChoicePanel.Instance.gameObject.SetActive(false);
    }
    public void OnRollButtonClick()
    {
        TowerChoicePanel.Instance.RollTowers();
    }

    IEnumerator Timer(float time)
    {
        while (time != 0)
        {            
            yield return new WaitForSeconds(1f);
            time--;
            timeUntilNextWaveText.text = time.ToString();
        }
    }

    public void ActivateTimerUntilNextWave(bool flag, float time)
    {
        timeUntilNextWaveText.gameObject.SetActive(flag);
        if (flag)
        {
            timeUntilNextWaveText.text = time.ToString();
            StartCoroutine(Timer(time));
        }
        else
            StopAllCoroutines();
    }

    public void ShowCurrentWaveIndex(int currentWave)
    {
        currentWaveText.text = "Wave: " + (currentWave+1);
        currentWaveText.DOFade(1f, 1f).OnComplete(() => { currentWaveText.DOFade(0f, 1f); }).Play();
    }
}
