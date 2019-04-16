using UnityEngine;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    [System.Serializable]
    public struct Wave
    {
        [System.Serializable]
        public struct SpawnPointData
        {
            public GameObject[] enemyPrefabs;
            public ObjectGenerator spawnPoint;
            public float spawnTime;
        }
        public float roundTime;
        public SpawnPointData[] spawnPointDatas;
    }
    public Wave[] waves;
}
