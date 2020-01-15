using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPatterns;
    public float startTimeBtwSpawn;
    public bool dead, startGame;

    private float timeBtwSpawn;

    private void Update()
    {
        if (startGame == true && dead == false)     //if game is run, and unicorn alive
        {
            //spawn random pattern of spawnpoints every specified time (startTimeBtwSpawn)
            if (timeBtwSpawn <= 0)
            {
                int rand = Random.Range(0, spawnPatterns.Length);
                Instantiate(spawnPatterns[rand], transform.position, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}
