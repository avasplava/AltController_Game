using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Sprite[] spriteList; //Used to store all of the different player sprites for ease of use!

    public GameObject playerOne;
    public GameObject playerTwo;

    public GameManager gm; //gets access to the GameManager script, so i can use the ProgressGain function here AS LONG AS THE FUNCTION IS PUBLIC!!!

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // TJ! seperate bools to check if each player is working
    public bool playerOneWorking;
    public bool playerTwoWorking;

    public TMP_Text playerOneWorkText;
    public TMP_Text playerTwoWorkText;

    void Start()
    {
        playerOne.GetComponent<SpriteRenderer>().sprite = spriteList[0]; //These will ensure that the players sprites are defaulted to Idle at the start of the scene
        playerTwo.GetComponent<SpriteRenderer>().sprite = spriteList[3];

        playerOneWorkText.text = ("Player One not working...");
        playerTwoWorkText.text = ("Player Two not working...");
    }

    // Update is called once per frame
    void Update()
    {
        // TJ, The bools are true if the input is pressed
        playerOneWorking = Input.GetKey(KeyCode.A);

        playerTwoWorking = Input.GetKey(KeyCode.D);

        //This is just to show if the players are pressing the buttons for playtesting?!
        if (playerOneWorking)
        {
            //Player One Writing Sprite
            playerOne.GetComponent<SpriteRenderer>().sprite = spriteList[1];
            playerOneWorkText.text = ("Player One working!!!");
        }
        else
        {
            //Back to Idle Sprite
            playerOne.GetComponent<SpriteRenderer>().sprite = spriteList[0];
            playerOneWorkText.text = ("Player One not working...");
        }

        if (playerTwoWorking)
        {
            //Player Two Writing Sprite
            playerTwo.GetComponent<SpriteRenderer>().sprite = spriteList[4];
            playerTwoWorkText.text = ("Player Two working!!!");
        }
        else
        {
            //Back to Idle Sprite
            playerTwo.GetComponent<SpriteRenderer>().sprite = spriteList[3];
            playerTwoWorkText.text = ("Player Two not working...");
        }

        //Debug.Log("Player One Working: " + playerOneWorking); //TJ I commented these out cause fills up debug log too much
        //Debug.Log("Player Two Working: " + playerTwoWorking);

        if (Input.GetButton("Jump")) //GetButton counts holds as well, GetButtonDown only detects a click if that makes sense
        {
            //Change Both Players to Kissing/Hand Holding Sprite
            gm.ProgressGain(0.09f); //the number just chooses how much the progress goes up each frame, can possibly slow this down with further coding
        }
        else if (!Input.GetButton("Jump") && !playerOneWorking && !playerTwoWorking)//If the players aren't holding down space or their hands AND not working
        {
            //Back to idle sprites
            playerOne.GetComponent<SpriteRenderer>().sprite = spriteList[0];
            playerTwo.GetComponent<SpriteRenderer>().sprite = spriteList[3];
            gm.ProgressDecrease(0.05f);
        }
    }
}
