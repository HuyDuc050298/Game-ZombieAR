using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] spawnPoint;
    public GameObject zombie;
    public GameObject zombieGirl;

    public float minSpawnTime = 5.0f;
    public float maxSpawnTime = 10.0f;
    private float lastSpawnTime = 0;
    private float lastSpawnTimeGirl = 0;
    private float spawnTime = 0;
    private float spawnTimeGirl = 5;
    private bool isSpawned = false;
    void Start()
    {

    }

    void RunGame()
    {
        spawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
        UpdateSpawnTime();
    }

    void UpdateSpawnTime()
    {

        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void UpdateSpawnTimeGirl()
    {
        lastSpawnTimeGirl = Time.time;
    }
    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(zombie, spawnPoint[point].transform.position, Quaternion.identity);
        UpdateSpawnTime();
    }

    void SpawnGirl()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(zombieGirl, spawnPoint[point].transform.position, Quaternion.identity); ;
        UpdateSpawnTimeGirl();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            GameController gs = GameObject.FindWithTag("GameController").GetComponent<GameController>();
            if (gs.isRunGame)
            {
                RunGame();
                isSpawned = true;
            }
        }
        else
        {
            if (Time.time >= lastSpawnTime + spawnTime)
            {
                Spawn();
            }
            if(Time.time >= lastSpawnTimeGirl+spawnTimeGirl)
            {
                SpawnGirl();
            }
        }

    }
}
