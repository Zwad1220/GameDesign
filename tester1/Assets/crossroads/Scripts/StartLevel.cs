using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class StartLevel : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public Controls Controls;
    public void Setup()
    {
        gameObject.SetActive(true);


    }

    public void yesButton()
    {
        gameObject.SetActive(false);
        Controls.Setup();
    }
    public void noButton()
    {
        choiceText.text = "you have no choice, press yes!";
    }
}
