using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float maxLoveMeter; //The maximum/goal amount of the progress meter
    public float currentLoveMeter;

    public Slider loveSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLoveMeter = 0;
        loveSlider.maxValue = maxLoveMeter;
        loveSlider.value = currentLoveMeter;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProgressGain (float amount)
    {
        currentLoveMeter += amount;
        loveSlider.value = currentLoveMeter;
    }
}
