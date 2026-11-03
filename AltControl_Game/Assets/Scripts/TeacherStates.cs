using UnityEngine;

public class TeacherStates : MonoBehaviour
{

    public enum TEACHER_STATE
    {
        Safe,
        Sus,
        Alert
    }

    public TEACHER_STATE teacherState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (teacherState)
        {
            case TEACHER_STATE.Safe:
                //Teacher sprite is normal teaching sprite
                //Every 5 seconds? make the teacher choose wheter or not to go into the Sus state
                break;

            case TEACHER_STATE.Sus:
                //Teacher sprite changes to the suspicious sprite gasp
                //This can be used to pysch the players out hehe
                //Can make the script decided whether the teacher switches back to Safe state or go into Alert state
                break;

            case TEACHER_STATE.Alert:
                //Teacher sprite changes to Alert sprite
                //The main important one to decide whether the player gets caught or not
                //Was thinking that the player loses progress if they aren't seen working and if they are caught holding hands they lose the game?
                break;
        }
    }
}
