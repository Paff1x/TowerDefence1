using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerChoicePanel : MonoBehaviour
{
    [SerializeField] private Tower[] towers;
    [SerializeField] private GameObject[] towerPlaces;


    public static TowerChoicePanel Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RollTowers()
    {
        foreach (GameObject towerPlace in towerPlaces)
        {
            if (towerPlace.transform.childCount != 0)
                Destroy(towerPlace.transform.GetChild(0).gameObject);
            Tower tower = Instantiate(towers[UnityEngine.Random.Range(0, towers.Length)],towerPlace.transform.position,towerPlace.transform.rotation);
            tower.transform.SetParent(towerPlace.transform);
        }
    }

}
