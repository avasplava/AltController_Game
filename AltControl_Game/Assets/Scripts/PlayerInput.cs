using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
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
            playerOneWorkText.text = ("Player One working!!!");
        }
        else
        {
            playerOneWorkText.text = ("Player One not working...");
        }

        if (playerTwoWorking)
        {
            playerTwoWorkText.text = ("Player Two working!!!");
        }
        else
        {
            playerTwoWorkText.text = ("Player Two not working...");
        }

        //Debug.Log("Player One Working: " + playerOneWorking); //TJ I commented these out cause fills up debug log too much
        //Debug.Log("Player Two Working: " + playerTwoWorking);

        if (Input.GetButton("Jump")) //GetButton counts holds as well, GetButtonDown only detects a click if that makes sense
        {
            gm.ProgressGain(0.02f); //the number just chooses how much the progress goes up each frame, can possibly slow this down with further coding
        }
        else //If the players aren't holding down space or their hands
        {
            gm.ProgressDecrease(0.01f);
        }
    }
}
