using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public TeamData[] availableTeams; // List of available teams

    public int enemiesPerGroup = 3; // Number of enemies to spawn in a group

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true) // You might have a condition to stop spawning waves
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                TeamData waveTeam = GetRandomTeam(); // Get a random team for the wave

                for (int i = 0; i < enemiesPerGroup; i++)
                {
                    SpawnEnemy(spawnPoint, waveTeam);
                    yield return new WaitForSeconds(0.5f); // Time between enemies in a group
                }
            }

            yield return new WaitForSeconds(5f); // Adjust time between waves
        }
    }

    private void SpawnEnemy(Transform spawnPoint, TeamData team)
    {
        GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.enemyTeam = team; // Assign the selected team
        // Initialize other properties
    }

    private TeamData GetRandomTeam()
    {
        int randomIndex = Random.Range(0, availableTeams.Length);
        return availableTeams[randomIndex];
    }
}
