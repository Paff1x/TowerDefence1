using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    internal TowerPlace ActiveTowerPlace;
    internal Tower DragableTower;

    public static TowerController Instance { get; private set; }



    private void Awake()
    {
        Instance = this;
    }

    public TowerPlace SetTower(Tower tower)
    {
        tower.transform.SetParent(null);
        tower.transform.position = ActiveTowerPlace.transform.position;
        tower.transform.rotation = ActiveTowerPlace.transform.rotation;
        ActiveTowerPlace.gameObject.SetActive(false);
        return ActiveTowerPlace;
    }
}
