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
    public float progressGain;
    public float progressLoss;

    public Slider loveSlider;
    public Slider clockSlider;

    public GameObject loseScreen; //TJ, the lose screen ui object is put here in da inspector
    public GameObject winScreen;
    public GameObject gameScene; //Ava :p, turns off the gameplay stuff to stop the player from interacting in the bg

    public float gameTimer = 60f; //it the game timer!

    public RectTransform minuteHand; // TJ, where u drag the clock hang image in the insepctor

    public TeacherStates teacher;
    public float caughtSequenceDuration = 2f;

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

        //TJ, rotating clock hand .... ahhh
        float progress = gameTimer / clockSlider.maxValue; // TJ, divides "time left" with the orignal starting time, to get a number value of how far along the clock is.
        float angle = (1f - progress) * 360f; // TJ, gets the angle of the clock hand based on the progress of the timer.
        minuteHand.eulerAngles = new Vector3(0, 0, -angle); // TJ, applys the rotation to the clock hand.

        if(gameTimer <= 0 && !player.controlsLocked)
        {
            LoseGame();
        }

        if (currentLoveMeter >= maxLoveMeter)
        {
            FullLoveBar();
        }
    }

    public void ProgressGain ()
    {
        currentLoveMeter += progressGain;
        loveSlider.value = currentLoveMeter;

        if (currentLoveMeter >= maxLoveMeter)
        {
            currentLoveMeter = maxLoveMeter;
        }
    }

    public void ProgressDecrease()
    {
        currentLoveMeter -= progressLoss;
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
        gameScene.SetActive(false);
    }

    public void RestartGame() //TJ, retry game function. to um... retry game hah
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FullLoveBar() //Triggers when the bar is FULL of love
    {
        winScreen.SetActive(true);
        gameScene.SetActive(false);
    }

    public void ResetGame()
    {
        player.controlsLocked = false;
        player.kissingSprite.SetActive(false);
        player.playerOne.SetActive(true);
        player.playerTwo.SetActive(true);
        player.playerOne.GetComponent<SpriteRenderer>().sprite = player.spriteList[0];
        player.playerTwo.GetComponent<SpriteRenderer>().sprite = player.spriteList[3];
        teacher.caughtAnimationPlaying = false;
        teacher.teacherState = TeacherStates.TEACHER_STATE.Safe;
        teacher.teacherTime = 0f;
        teacher.teacherSprite.sprite = teacher.teacherSprites[0];
        currentLoveMeter = 0;
        gameTimer = clockSlider.maxValue;
        loveSlider.value = currentLoveMeter;
        clockSlider.value = gameTimer;
    }

    public void StartCaughtSequence(bool endGame)
    {
        StartCoroutine(CaughtSequence(endGame));
    }

    IEnumerator CaughtSequence(bool endGame)
    {
        player.controlsLocked = true;
        player.kissingSprite.SetActive(false);

        player.playerOne.SetActive(true);
        player.playerTwo.SetActive(true);

        player.playerOne.GetComponent<SpriteRenderer>().sprite = player.spriteList[2];
        player.playerTwo.GetComponent<SpriteRenderer>().sprite = player.spriteList[5];
        
        teacher.caughtAnimationPlaying = true;
        teacher.teacherSprite.sprite = teacher.teacherSprites[3];
        
        yield return new WaitForSeconds(caughtSequenceDuration);

        if (endGame)
        {
            LoseGame();
        }
        else
        {
            player.controlsLocked = false;
            teacher.caughtAnimationPlaying = false;
            teacher.teacherState = TeacherStates.TEACHER_STATE.Safe;
            teacher.teacherTime = 0f;
        }
    }

}
