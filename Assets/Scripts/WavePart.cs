using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WavePart
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float spawnRate;
    public float timeToNextPartWave;
}
