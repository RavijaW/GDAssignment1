using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGo;
    float maxSpawnRateInSeconds=5f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

    
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
        anEnemy.transform.position=new Vector2 (Random.Range(min.x, max.x),max.y);

        ScheduleNextEnemySpawn ();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds >1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds=1f;

        Invoke ("SpawnEnemy", spawnInSeconds);
        
    }

    //to increase spawnrate
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds>1f)
            maxSpawnRateInSeconds--;

        if(maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");    
    }

    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds=5f;

        Invoke("SpawnEnemy",maxSpawnRateInSeconds);

        //incrwase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate",0f,30f);

    }


    public void UnsheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
