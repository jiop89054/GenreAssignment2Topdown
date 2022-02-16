using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject turret;
    public GameObject strafer;
    private int quadrant;
    private float randX;
    private float randY;
    private Vector2 whereToSpawn;
    public float spawnRateChaser = 2.0f;
    public float nextSpawnChaser = 0.5f;
    public float spawnRateTurret = 4.5f;
    public float nextSpawnTurret = 5.0f;
    public float spawnRateStrafer = 7.0f;
    public float nextSpawnStrafer = 7.5f;
    public float difficultyTimer = 5.0f;
    void Update()
    {
        if(Time.timeSinceLevelLoad > nextSpawnChaser)
        {
            nextSpawnChaser = nextSpawnChaser + spawnRateChaser;
            pickSpawn();
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        if (Time.timeSinceLevelLoad > nextSpawnTurret)
        {
            nextSpawnTurret = nextSpawnTurret + spawnRateTurret;
            pickSpawn();
            Instantiate(turret, whereToSpawn, Quaternion.identity);
        }
        if (Time.timeSinceLevelLoad > nextSpawnStrafer)
        {
            nextSpawnStrafer = nextSpawnStrafer + spawnRateStrafer;
            pickSpawn();
            Instantiate(strafer, whereToSpawn, Quaternion.identity);
        }
        if (Time.timeSinceLevelLoad > difficultyTimer&& spawnRateChaser > 0.2f)
        {
            difficultyTimer = difficultyTimer + 5;
            spawnRateChaser = spawnRateChaser * 0.9f;
            spawnRateTurret = spawnRateTurret * 0.9f;
        }
        
    }
    public void pickSpawn()
    {
        quadrant = Random.Range(1, 4);
        if (quadrant == 1)
        {
            randX = Random.Range(-16.7f, 16.7f);
            randY = -9.4f;
            whereToSpawn = new Vector2(randX, randY);
        }
        if (quadrant == 2)
        {
            randX = Random.Range(-16.7f, 16.7f);
            randY = 9.4f;
            whereToSpawn = new Vector2(randX, randY);
        }
        if (quadrant == 3)
        {
            randY = Random.Range(-9.2f, 9.2f);
            randX = 16.9f;
            whereToSpawn = new Vector2(randX, randY);
        }
        if (quadrant == 3)
        {
            randY = Random.Range(-9.2f, 9.2f);
            randX = -16.9f;
            whereToSpawn = new Vector2(randX, randY);
        }
        FindObjectOfType<AudioManager>().Play("EnemySpawn");
    }
}
