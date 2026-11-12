using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public GameObject gameScene;
    public GameManager gm;

    [Header("TutorialPlayer Visuals")]
    public Sprite[] spriteList;

    public Image playerOne;
    public Image playerTwo;
    
    public TMP_Text playerOneWorkText;
    public TMP_Text playerTwoWorkText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (titleScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (tutorialScreen.activeSelf)
        {
            bool playerOneWorking = Input.GetKey(KeyCode.A);
            bool playerTwoWorking = Input.GetKey(KeyCode.D);

            if (playerOneWorking)
            {
                playerOne.sprite = spriteList[1];
                playerOneWorkText.text = ("Player One working!!!");
            }
            else
            {
                playerOne.sprite = spriteList[0];
                playerOneWorkText.text = ("Player One not working...");
            }

            if (playerTwoWorking)
            {
                playerTwo.sprite = spriteList[4];
                playerTwoWorkText.text = ("Player Two working!!!");
            }
            else
            {
                playerTwo.sprite = spriteList[3];
                playerTwoWorkText.text = ("Player Two not working...");
            }

            if (playerOneWorking && playerTwoWorking)
            {
                ContinueToGame();
            }
        }      
    }

    public void StartGame() //TJ, starts the game when the player presses the start button
    {
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void ContinueToGame() //TJ, continues to the game when the player moves on from the tutoral screen
    {
        gm.winScreen.SetActive(false);
        gm.loseScreen.SetActive(false);
        
        tutorialScreen.SetActive(false);
        gameScene.SetActive(true);

        //Reset timer and love meter
        gm.currentLoveMeter = 0;
        gm.gameTimer = gm.clockSlider.maxValue;

        gm.loveSlider.value = gm.currentLoveMeter;
        gm.clockSlider.value = gm.gameTimer;
    }

        public void ReturnToMenu()
    {
        titleScreen.SetActive(true);
        tutorialScreen.SetActive(false);
        gameScene.SetActive(false);

        gm.winScreen.SetActive(false);
        gm.loseScreen.SetActive(false);
    }


}
