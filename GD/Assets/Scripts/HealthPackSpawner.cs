using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject HealthPackGo;

    float maxPackSpawnRateInSeconds=5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnHealthPack", maxPackSpawnRateInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnHealthPack()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject aHealthPack = (GameObject)Instantiate(HealthPackGo);
        aHealthPack.transform.position = new Vector2(Random.Range (min.x,max.x),max.y);

        ScheduleNextHealthPackSpawn();
    }

    void ScheduleNextHealthPackSpawn()
    {
        float spawnInNseconds;
         if (maxPackSpawnRateInSeconds > 30f)
         {
             spawnInNseconds = Random.Range(30f,maxPackSpawnRateInSeconds);
         }

         else
            spawnInNseconds = 30f;

        Invoke ("SpawnHealthPack",spawnInNseconds);
    }
}
