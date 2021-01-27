using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    //public Transform enemyPrefab; with Wavespawner 1.0

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 15f;

    public Text waveCountdownText;
    public Text waveIndexText;

    private int waveIndex = 0;

    public GameManager gameManager;
    void Start()
    {
        EnemiesAlive = 0;
        waveIndexText.text = (waveIndex).ToString() + " / " + waves.Length.ToString();
    }
    void Update()
    {
        //Stoping enemies from spawning if there is at least 1 alive
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; //delete this return if not using Wave 2.0
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown).Replace(",", ".");
    }

    IEnumerator SpawnWave() 
    {
        waveIndexText.text = (waveIndex + 1).ToString() + " / " + waves.Length.ToString();
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        int enemiesAlive = 0;

        for (int i = 0; i < wave.wavesParts.Length; i++)
        {
             enemiesAlive += wave.wavesParts[i].enemyCount;
        }

        EnemiesAlive = enemiesAlive;

        for (int i = 0; i < wave.wavesParts.Length; i++)
        {
            for (int y = 0; y < wave.wavesParts[i].enemyCount; y++)
            {
                 SpawnEnemy(wave.wavesParts[i].enemyPrefab);
                 yield return new WaitForSeconds(1f / wave.wavesParts[i].spawnRate);
            }
            yield return new WaitForSeconds(wave.wavesParts[i].timeToNextPartWave);
        }
        waveIndex++;
        
    }
    void SpawnEnemy(GameObject enemy) 
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
