using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [System.Serializable]
    public class Wave {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    public Transform parent;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    private bool isFinishedSpawning;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));

    }

    IEnumerator StartNextWave(int index) {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpwanWave(index));
    }

    IEnumerator SpwanWave(int index) {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++) {
            if (player == null) {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation,parent);

            isFinishedSpawning = i == (currentWave.count -1);
 

            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
        }
    }  

    void Update() {
        if (isFinishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            isFinishedSpawning = false;

            if (currentWaveIndex + 1 < waves.Length) {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
        }
    }
}
