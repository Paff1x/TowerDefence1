using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private float spawnTime;

    [SerializeField] private GameObject[] prefabs;



    private void OnEnable()
    {
        StartCoroutine(SpawnDelay());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }
    private void Spawn()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, transform.rotation);
    }

    public void Init(GameObject [] _prefabs, float _spawnTime)
    {
        prefabs = _prefabs;
        spawnTime = _spawnTime;
    }
}
