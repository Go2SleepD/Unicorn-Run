using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    public AudioClip jumpSound, coinSound, boostSound, btnSound, memeDeath, classicDeath;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "jumpSound":
                audioSource.PlayOneShot(jumpSound, 0.7f);       //clip, volume
                break;

            case "coinSound":
                audioSource.PlayOneShot(coinSound);
                break;

            case "boostSound":
                audioSource.PlayOneShot(boostSound);
                break;

            case "buttonSound":
                audioSource.PlayOneShot(btnSound);
                break;

            case "classic":
                audioSource.PlayOneShot(classicDeath);
                break;

            case "meme":
                audioSource.PlayOneShot(memeDeath);
                break;
        }

    }

}
