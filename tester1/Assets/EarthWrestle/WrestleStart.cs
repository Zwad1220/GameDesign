using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class WrestleStart : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public EarthControls earthControls;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void yesButton()
    {
        if (choiceText.text != "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            earthControls.Setup();
        }
        else gameObject.SetActive(false);
    }
    public void noButton()
    {
        if (choiceText.text == "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            earthControls.Setup();
        }
        choiceText.text = "are you sure you want to stay a cat forever?";
    }
}
