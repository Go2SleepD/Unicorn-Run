using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    public GameObject restartPannel;

    private GameObject gameMaster;
    private GameObject[] obstacles;
    private AudioSource deathSound, backgoundMusic;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");

        deathSound = GetComponent<AudioSource>();
        backgoundMusic = gameMaster.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))     //when player contact with death line
        {
            gameMaster.GetComponent<GameMaster>().Dead(true);       //unicorn becomes dead then collide

            DestroyObstacles("Box");        //destroy all boxes
            DestroyObstacles("Coin");       //destroy all coins
            DestroyObstacles("Poision");        //destroy all poitions
        }
    }

    private void DestroyObstacles(string tagName)
    {
        obstacles = GameObject.FindGameObjectsWithTag(tagName);       //find all obstacle with specified name on scene 
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().SelfDestroy(0.1f);      //destroy all obstacles, which was founded
        }
    }
}
