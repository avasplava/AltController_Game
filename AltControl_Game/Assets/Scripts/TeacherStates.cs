using System.Threading;
using TMPro;
using UnityEngine;

public class TeacherStates : MonoBehaviour
{
    public TMP_Text stateText;
    public float teacherTime;

    public GameManager gm;

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
                    int stateChangeChance = Random.Range(1, 10);

                    if (stateChangeChance <= 5)
                    {
                        Debug.Log("Safe State");
                        teacherState = TEACHER_STATE.Safe;
                        teacherTime = 0f;
                    }
                    if (stateChangeChance >= 6)
                    {
                        Debug.Log("Sus State");
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
                break;

            case TEACHER_STATE.Danger:
                stateText.text = ("State: Danger!");
                //Teacher sprite changes to Alert sprite
                //The main important one to decide whether the player gets caught or not
                //Was thinking that the player loses progress if they aren't seen working and if they are caught holding hands they lose the game?
                if (!Input.GetButton("Jump"))
                {
                    Debug.Log("You've been caught!"); //Just to make sure it works
                    gm.ProgressDecrease(20f);
                    teacherState = TEACHER_STATE.Safe;
                }
                break;
        }
    }
}
