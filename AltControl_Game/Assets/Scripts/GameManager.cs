using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float maxLoveMeter; //The maximum/goal amount of the progress meter
    public float currentLoveMeter;

    public Slider playerOneSlider;
    public Slider playerTwoSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLoveMeter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProgressGain (float amount)
    {
        currentLoveMeter += amount;

    }
}
