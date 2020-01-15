using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class OptionsMenu : MonoBehaviour
{
    public Slider volumeLvl;
    
    //public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //audioMixer.SetFloat("volume", volume);
    }
}
