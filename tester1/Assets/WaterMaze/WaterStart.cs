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
        gameObject.SetActive(false);
        waterControls.Setup();
    }
    public void noButton()
    {
        choiceText.text = "you have no choice, press yes!";
    }
}