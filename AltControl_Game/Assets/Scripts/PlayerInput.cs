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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TJ, The bools are true if the input is pressed
        playerOneWorking = Input.GetKey(KeyCode.A);

        playerTwoWorking = Input.GetKey(KeyCode.D);

        //Debug.Log("Player One Working: " + playerOneWorking); //TJ I commented these out cause fills up debug log too much
        //Debug.Log("Player Two Working: " + playerTwoWorking);

        if (Input.GetButton("Jump")) //GetButton counts holds as well, GetButtonDown only detects a click if that makes sense
        {
            gm.ProgressGain(0.01f); //the number just chooses how much the progress goes up each frame, can possibly slow this down with further coding
        }
        else //If the players aren't holding down space or their hands
        {
            gm.ProgressDecrease(0.01f);
        }
    }
}
