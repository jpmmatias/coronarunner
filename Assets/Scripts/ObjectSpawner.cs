using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] coins;


    public GameObject[] obstacles;
    public GameObject enemy;
    public GameObject[] scenarios;
    public GameObject[] powerUps;
    private float coinSpawnTimer = 1.0f;
    private float scenarioSpawnTimer = 3.65f;
    public float backgroundSpawnTimer = 10.0f;
    public float enemySpawnTimer = 2.0f;
    private float obstacleSpawnTimer = 2f;


    private float powerupSpawnTimer = 15f;
    private float randomSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinSpawnTimer -= Time.deltaTime;
        enemySpawnTimer -= Time.deltaTime;
        powerupSpawnTimer -= Time.deltaTime;
        obstacleSpawnTimer -= Time.deltaTime;
        scenarioSpawnTimer -= Time.deltaTime;




        if (coinSpawnTimer < 0.01)
        {
            SpawnCoins();
        }
        if (scenarioSpawnTimer < 0.01)
        {
            ScenarioSpawn();
        }


        if (enemySpawnTimer < 0.01)
        {
            SpawnEnemy();
        }

        if (powerupSpawnTimer < 0.01)
        {
            SpawnPowerUps();
        }
        if (obstacleSpawnTimer < 0.01)
        {
            SpawnObstacles();
        }




    }

    void SpawnCoins()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(player.transform.position.x + 30, Random.Range(0, 3.5f), 0), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 5.0f);
    }

    void SpawnPowerUps()
    {
        Instantiate(powerUps[(Random.Range(0, powerUps.Length))], new Vector3(player.transform.position.x + 30, 1, 0), Quaternion.identity);
        powerupSpawnTimer = Random.Range(10.0f, 40.0f);
    }
    void ScenarioSpawn()
    {
        Instantiate(scenarios[(Random.Range(0, scenarios.Length))], new Vector3(player.transform.position.x + 25, 0, 0), Quaternion.identity);
        scenarioSpawnTimer = 2.55f;
    }
    void SpawnObstacles()
    {
        Instantiate(obstacles[(Random.Range(0, obstacles.Length))], new Vector3(player.transform.position.x + 30, .55f, 0), Quaternion.identity);
        obstacleSpawnTimer = Random.Range(7.0f, 10.0f);
    }

    void SpawnEnemy()
    {
        randomSize = Random.Range(0.04f, 0.06f);
        enemy.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        Instantiate(enemy, new Vector3(player.transform.position.x + 30, Random.Range(0.76f, 4f), 0), Quaternion.identity);
        enemySpawnTimer = Random.Range(2, 4);

    }

}
