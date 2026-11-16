using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class TeacherStates : MonoBehaviour
{
    public TMP_Text stateText;
    public float teacherTime;
    public float teacherProgressDecrease;

    public SpriteRenderer teacherSprite;
    public Sprite[] teacherSprites; //0 = writing on board, 1 = sus , 2 Danger , 3 = Angry

    public GameManager gm;

    public PlayerInput playerInput; //TJ ! gets access to the PlayerInput script, so i can use the bools for each player working

    public enum TEACHER_STATE //Lets me design seperate states for the teacher, hopefully making it easier to playtest
    {
        Safe,
        Sus,
        Danger
    }

    public TEACHER_STATE teacherState;

    public bool caughtAnimationPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateText.text = ("State: Safe");
        teacherTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (caughtAnimationPlaying)
        {
            return;
        }
        teacherTime += Time.deltaTime;

        switch (teacherState)
        {
            case TEACHER_STATE.Safe:
                stateText.text = ("State: Safe");
                teacherSprite.sprite = teacherSprites[0];
                 //Teacher sprite is normal teaching sprite
                //Every few seconds make the teacher choose wheter or not to go into the Sus state
                if (teacherTime >= 3f)
                {
                    Debug.Log("Timer hit 3 seconds, teacher going into Sus mode maybe idk bruh");
                    //RANDOM THINGY HERE GAH
                    int stateChangeChance = Random.Range(1, 6);

                    if (stateChangeChance == 1)
                    {
                        Debug.Log("Change to Safe State");
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                    if (stateChangeChance >= 2)
                    {
                        Debug.Log("Change to Sus State");
                        teacherState = TEACHER_STATE.Sus;
                        teacherTime = 0f;
                    }
                }
                break;

            case TEACHER_STATE.Sus:
                stateText.text = ("State: Sus");
                teacherSprite.sprite = teacherSprites[1];
                //Teacher sprite changes to the suspicious sprite gasp
                //This can be used to pysch the players out hehe
                //Can make the script decide whether the teacher switches back to Safe state or go into Danger state

                float teacherTimeChange = Random.Range(1f, 3f); //picks out a random time for the teacher to stay in this state for
                Debug.Log("New teacher time: " + teacherTimeChange);
                if (teacherTime >= teacherTimeChange)
                {
                    int stateChangeChance = Random.Range(1, 5);

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
                teacherSprite.sprite = teacherSprites[2];
                //Teacher sprite changes to Alert sprite
                //The main important one to decide whether the player gets caught or not
                if (Input.GetButton("Jump")) //If players are holding hands
                {
                    //Change player sprites to the Caught Ones!
                    Debug.Log("You've been caught!"); //Just to make sure it works
                    gm.StartCaughtSequence(true);
                }
                else if (playerInput.playerOneWorking && playerInput.playerTwoWorking) //TJ! Checks if both players are working
                {
                    //Debug.Log("Everyone is working. Safe"); // TJ! commented out cause fills up debug log
                    if (teacherTime >= 2.5f)
                    {
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                }
                //if they arent kissing or working, lose progress
                else
                {
                    Debug.Log("Someone isnt working");
                    gm.currentLoveMeter -= teacherProgressDecrease;
                    gm.currentLoveMeter = Mathf.Max(0, gm.currentLoveMeter); //makes sure the love meter doesn't go below 0
                    gm.loveSlider.value = gm.currentLoveMeter;
                    //gm.ProgressDecrease();
                    teacherState = TEACHER_STATE.Safe;
                    gm.StartCaughtSequence(false);     
                }
                break;
        }
    }
}
