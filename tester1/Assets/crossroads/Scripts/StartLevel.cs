using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Jobs;

public class StartLevel : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public Controls Controls;
    public regenerateLevels regenerateLevels;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void yesButton()
    {
        if (choiceText.text != "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            Controls.Setup();
        }
        else gameObject.SetActive(false);
        regenerateLevels.disappear();
    }
    public void noButton()
    {
        if (choiceText.text == "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            Controls.Setup();
        }
        choiceText.text = "are you sure you want to stay a cat forever?";
    }


}

