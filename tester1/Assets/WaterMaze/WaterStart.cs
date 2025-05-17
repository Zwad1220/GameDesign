using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterStart : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public WaterControls waterControls;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void yesButton()
    {
        if (choiceText.text != "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            waterControls.Setup();
        }
        else gameObject.SetActive(false);
    }
    public void noButton()
    {
        if (choiceText.text == "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            waterControls.Setup();
        }
        choiceText.text = "are you sure you want to stay a cat forever?";
    }
}