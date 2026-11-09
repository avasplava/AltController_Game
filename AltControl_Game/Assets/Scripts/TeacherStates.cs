using System.Threading;
using TMPro;
using UnityEngine;

public class TeacherStates : MonoBehaviour
{
    public TMP_Text stateText;
    public float teacherTime;

    public GameManager gm;

    public PlayerInput playerInput; //TJ ! gets access to the PlayerInput script, so i can use the bools for each player working

    public enum TEACHER_STATE //Lets me design seperate states for the teacher, hopefully making it easier to playtest
    {
        Safe,
        Sus,
        Danger
    }

    public TEACHER_STATE teacherState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateText.text = ("State: Safe");
        teacherTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        teacherTime += Time.deltaTime;

        switch (teacherState)
        {
            case TEACHER_STATE.Safe:
                stateText.text = ("State: Safe");
                //Teacher sprite is normal teaching sprite
                //Every 5 seconds? make the teacher choose wheter or not to go into the Sus state
                if (teacherTime >= 5f)
                {
                    Debug.Log("Timer hit 5 seconds, teacher going into Sus mode maybe idk bruh");
                    //RANDOM THINGY HERE GAH
                    int stateChangeChance = Random.Range(1, 5);

                    if (stateChangeChance <= 2)
                    {
                        Debug.Log("Change to Safe State");
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                    if (stateChangeChance >= 3)
                    {
                        Debug.Log("Change to Sus State");
                        teacherState = TEACHER_STATE.Sus;
                        teacherTime = 0f;
                    }
                }
                break;

            case TEACHER_STATE.Sus:
                stateText.text = ("State: Sus");
                //Teacher sprite changes to the suspicious sprite gasp
                //This can be used to pysch the players out hehe
                //Can make the script decided whether the teacher switches back to Safe state or go into Alert state

                if (teacherTime >= 3f) //Change this to be between like 2 to five seconds randomly
                {
                    int stateChangeChance = Random.Range(1, 10);

                    if (stateChangeChance <= 2)
                    {
                        Debug.Log("Change to Safe State");
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                    if (stateChangeChance >= 3)
                    {
                        Debug.Log("Change to DANGER State");
                        teacherState = TEACHER_STATE.Danger;
                        teacherTime = 0f;
                    }
                }
                break;

            case TEACHER_STATE.Danger:
                stateText.text = ("State: Danger!");
                //Teacher sprite changes to Alert sprite
                //The main important one to decide whether the player gets caught or not
                if (Input.GetButton("Jump"))
                {
                    //Change player sprites to the Caught Ones!
                    Debug.Log("You've been caught!"); //Just to make sure it works
                    gm.LoseGame(); //TJ! calls losegame function in game manager script
                    teacherState = TEACHER_STATE.Safe;
                }
                else if (playerInput.playerOneWorking && playerInput.playerTwoWorking) //TJ! Checks if both players are working
                {
                    //Debug.Log("Everyone is working. Safe"); // TJ! commented out cause fills up debug log
                    if (teacherTime >= 3f)
                    {
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                }
                //if they arent kissing or working, lose progress
                else
                {
                    Debug.Log("Someone isnt working");
                    gm.ProgressDecrease(10f);
                    teacherState = TEACHER_STATE.Safe;      
                }
                break;
        }
    }
}
