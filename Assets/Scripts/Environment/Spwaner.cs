using System.Collections;
using UnityEngine;
using System.Linq;

public class WaveSpawner : MonoBehaviour {

    public Enemy[] enemies;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    public float timeBetweenSpawns;
    public int count;

    public Transform parent;

    private int waveCounter = 0;
    private Transform player;
    private bool isFinishedSpawning;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(waveCounter));

    }

    IEnumerator StartNextWave(int index) {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpwanWave(index));
    }

    IEnumerator SpwanWave(int index) {
        for (int i = 0; i < count; i++) {
            if (player == null) {
                yield break;
            }

            Enemy[] filteredEnemies = enemies.Where(e => waveCounter >= e.waveMinLevel).ToArray();
            Enemy randomEnemy = filteredEnemies[Random.Range(0, filteredEnemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation,parent);

            isFinishedSpawning = i == (count -1);
 
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }  

    void Update() {
        if (isFinishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            isFinishedSpawning = false;
            waveCounter++;
            count += waveCounter;
            StartCoroutine(StartNextWave(waveCounter));
        }
    }
}
