using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public GameObject gameScene;
    public GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueToGame();
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
