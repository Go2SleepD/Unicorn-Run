using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject gameMaster, audioMaster;

    public float speed;
    public bool dead;

    // Update is called once per frame
    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        audioMaster = GameObject.FindGameObjectWithTag("AudioMaster");

        SelfDestroy(3);    
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);     //moves box by speed
    }

    private void OnTriggerEnter2D(Collider2D collision)     //trigger condition for coins and poisions
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.tag)     //check what collide with unicorn
            {
                case "Box":
                    Handheld.Vibrate();
                    break;

                case "Coin":
                    gameMaster.GetComponent<GameMaster>().score++;     //score up
                    audioMaster.GetComponent<AudioMaster>().PlaySound("coinSound");     //turn on coin sound
                    Destroy(gameObject, 0.1f);      //destroy
                    break;

                case "Poision":
                    audioMaster.GetComponent<AudioMaster>().PlaySound("boostSound");     //turn on coin sound
                    gameMaster.GetComponent<GameMaster>().MoveToStart(5f);
                    Destroy(gameObject, 0.1f);      //destroy
                    break;
            }
        }
    }

    public void SelfDestroy(float time)     //box self destroy in specified time by time variable
    {
        Destroy(gameObject, time);
    }
}
