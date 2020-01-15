using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private GameObject pattern;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pattern"))        //clean game scene from spawn points, which are done their function
        {
            pattern = GameObject.FindGameObjectWithTag("Pattern");
            Destroy(pattern, 1f);
        }
    }
}
