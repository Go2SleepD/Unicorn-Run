using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class GameMaster : MonoBehaviour
{
    public GameObject menu, unicorn, deathLine, monster, restartPannel, spawner, floor1, floor2, dirt, mainCamera, audioMaster;
    public int score, hightScore = 0;
    public Text hightScoreText, scoreText;
    public Slider volumeLvl;
    public AudioMixer audioMixer;

    private Animator animMenu, animUnicorn, animMonster, animCam; //all animations 
    private AudioSource backgoundMusic;

    private void Start()
    {
        backgoundMusic = GetComponent<AudioSource>();     //get bg audiosource

        //get all animations
        animCam = mainCamera.GetComponent<Animator>();
        animMenu = menu.GetComponent<Animator>();
        animUnicorn = unicorn.GetComponent<Animator>();
        animMonster = monster.GetComponent<Animator>();

        PlayerPrefs.SetString("deathSound", "classic");

        GameRun(false);     //game isn't start
        Dead(false);        //unicorn is alive
    }

    private void Update()
    {
        hightScoreText.text = PlayerPrefs.GetInt("hightScore").ToString();      //shows hightscore info on scoreboard
        scoreText.text = score.ToString();      //shows current score
    }

    public void Dead(bool isDead)       //this method change info, then unicorn is dead or not dead
    {
        //bool triggers
        unicorn.GetComponent<Player>().dead = isDead;       //false -> can jump,  true -> can't jump
        floor1.GetComponent<Mover>().dead = isDead;      //false -> floor moves, true -> floor stop
        floor2.GetComponent<Mover>().dead = isDead;      //false -> floor moves, true -> floor stop 
        spawner.GetComponent<Spawner>().dead = isDead;      //false -> spawn particles, true ->don't pawn particles *
        restartPannel.SetActive(isDead);        //active or deactive lose menu

        //animations
        animMonster.SetBool("isDead", isDead);      //false -> monster run, true -> monster kill
        animUnicorn.SetBool("isDead", isDead);      //false -> unic run, true -> unic dead anim
        animCam.SetBool("isDead", isDead);      //flse -> cam idle, true -> cam death

        switch (isDead)
        {
            case true:
                dirt.SetActive(false);      //turn off dirt effect
                backgoundMusic.Stop();      //stop the background music
                audioMaster.GetComponent<AudioMaster>().PlaySound(PlayerPrefs.GetString("deathSound"));
                //deathSound.Play();      //play death sound or music 


                if (PlayerPrefs.GetInt("hightScore") < score)       //check is score bigger than hightscore
                {
                    PlayerPrefs.SetInt("hightScore", score);        //re-write hightscore
                }
                break;

            case false:
                audioMaster.GetComponent<AudioMaster>().audioSource.Stop();
                //deathSound.Stop();      //stops death sound or music
                backgoundMusic.Play();      //play background music
                break;
        }
    }

    public void GameRun(bool gameRun)       //this method change info, then game is run or not
    {
        //bool triggers
        spawner.GetComponent<Spawner>().startGame = gameRun;      //false -> spawn particles, true ->don't pawn particles *
        floor1.GetComponent<Mover>().startGame = gameRun;      //false -> floor moves, true -> floor stop 
        floor2.GetComponent<Mover>().startGame = gameRun;       //false -> floor moves, true -> floor stop 

        //animations
        animMenu.SetBool("gameRun", gameRun);       //false -> menu idle and visible, true -> menu run and out of screen view
        animUnicorn.SetBool("gameRun", gameRun);        //change gameRun trigger. (oh really?)
        animMonster.SetBool("gameRun", gameRun);
    }

    public void MoveToStart(float speed)        //method to boost or teleport unicorn
    {
        if (speed < 100f)
        {
            unicorn.GetComponent<Player>().speed = speed;       //moves player to start point with specified speed
            unicorn.GetComponent<Player>().moveToStart = true;       //initiate move to start
        }
        else
        {
            unicorn.transform.position = unicorn.GetComponent<Player>().startPos.position;
        }
    }

    public void PlayBtn()       //method for play button
    {
        audioMaster.GetComponent<AudioMaster>().PlaySound("buttonSound");       //poop sound
        dirt.SetActive(true);       //turn on dirt effect
        GameRun(true);      //starts the game
    }

    public void RestartBtn()        //method for restart button
    {
        audioMaster.GetComponent<AudioMaster>().PlaySound("buttonSound");       //poop sound
        MoveToStart(10f);

        score = 0;      //score to 0, when unic is dead
        dirt.SetActive(true);       //turn on dirt effect

        Dead(false);        //bring unicorn to life 
    }

    public void MenuBtn()       //method for back to menu button
    {
        audioMaster.GetComponent<AudioMaster>().PlaySound("buttonSound");       //poop sound
        MoveToStart(100f);
        score = 0;      //score to 0, when unic is dead

        GameRun(false);     //stops the game to main menu condition
        Dead(false);        //bring unicorn to life
    }

    public void OptionsBtn()        // methond for options btn
    {
        audioMaster.GetComponent<AudioMaster>().PlaySound("buttonSound");       //poop sound
        animMenu.SetBool("options", true);
    }

    public void BackBtn()
    {
        audioMaster.GetComponent<AudioMaster>().PlaySound("buttonSound");       //poop sound
        animMenu.SetBool("options", false);
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("volume", volumeLvl.value);
    }

    public void ChangeDeathMusic(int number)
    {
        switch(number)
        {
            case 0:
                PlayerPrefs.SetString("deathSound", "classic");
                break;

            case 1:
                PlayerPrefs.SetString("deathSound", "meme");
                break;
        }
    }
    public void ExitBtn()       //method for exit from game (close app)
    {
        Application.Quit();
    }
}
