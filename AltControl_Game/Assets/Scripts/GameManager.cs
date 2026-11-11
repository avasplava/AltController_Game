using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerInput player;

    public float maxLoveMeter; //The maximum/goal amount of the progress meter
    public float currentLoveMeter;

    public Slider loveSlider;
    public Slider clockSlider;

    public GameObject loseScreen; //TJ, the lose screen ui object is put here in da inspector
    public GameObject winScreen;
    public GameObject gameScene; //Ava :p, turns off the gameplay stuff to stop the player from interacting in the bg

    public float gameTimer; //it the game timer!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLoveMeter = 0;
        loveSlider.maxValue = maxLoveMeter;
        loveSlider.value = currentLoveMeter;

        clockSlider.maxValue = gameTimer;
        clockSlider.value = gameTimer;

        //gameTimer = 10; //testing testing, can be changed in inspector anyways
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        clockSlider.value = gameTimer;

        if(gameTimer <= 0)
        {
            LoseGame();
        }

        if (currentLoveMeter >= maxLoveMeter)
        {
            FullLoveBar();
        }
    }

    public void ProgressGain (float amount)
    {
        currentLoveMeter += amount;
        loveSlider.value = currentLoveMeter;

        if (currentLoveMeter >= maxLoveMeter)
        {
            currentLoveMeter = maxLoveMeter;
        }
    }

    public void ProgressDecrease(float amount)
    {
        currentLoveMeter -= amount;
        loveSlider.value = currentLoveMeter;

        if (currentLoveMeter <= 0)
        {
            currentLoveMeter = 0;
        }
    }

    public void LoseGame() //TJ, sets the losescreen object to active when the player losers. Call this function when the player loses
    {
        player.playerOne.GetComponent<SpriteRenderer>().sprite = player.spriteList[2];
        player.playerTwo.GetComponent<SpriteRenderer>().sprite = player.spriteList[5];

        

        loseScreen.SetActive(true);
        //gameScene.SetActive(false);
    }

    public void RetryGame() //TJ, retry game function. to um... retry game hah
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FullLoveBar() //Triggers when the bar is FULL of love
    {
        winScreen.SetActive(true);
        gameScene.SetActive(false);
    }

}
