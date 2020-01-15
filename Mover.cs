using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float startx, endx;
    public bool dead, startGame;

    void Update()
    {
        if (startGame == true && dead == false)     //if game is run, and unicorn alive
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= endx)         //when platform reach end-point, platform teleports to start 
            {
                Vector2 pos = new Vector2(startx, transform.position.y);        //teleports platform to start
                transform.position = pos;       
            }
        }
    }
}
