using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    [SerializeField] private HealthBar healthBar;
    public static Base Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        healthBar.gameObject.SetActive(true);
    }
}
