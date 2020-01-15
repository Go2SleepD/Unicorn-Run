using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] obstacle;
    public bool dead;
    private void Start()
    {
        if (dead == false)      //spawn obstacles if unic alive
        {
            int rand = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[rand], transform.position, Quaternion.identity);
        }
    }
}
