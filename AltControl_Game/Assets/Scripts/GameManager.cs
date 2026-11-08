using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float maxLoveMeter; //The maximum/goal amount of the progress meter
    public float currentLoveMeter;

    public Slider loveSlider;

    public GameObject loseScreen; //TJ, the lose screen ui object is put here in da inspector

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

        if (currentLoveMeter >= maxLoveMeter)
        {
            currentLoveMeter = maxLoveMeter;
        }
    }

    public void ProgressDecrease(float amount)
    {
        currentLoveMeter -= amount;
        loveSlider.value = currentLoveMeter;

        if (currentLoveMeter <= 0)
        {
            currentLoveMeter = 0;
        }
    }

    public void LoseGame() //TJ, sets the losescreen object to active when the player losers. Call this function when the player loses
    {
        loseScreen.SetActive(true);
    }

    public void RetryGame() //TJ, retry game function. to um... retry game hah
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
