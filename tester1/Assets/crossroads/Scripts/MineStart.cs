using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineStart : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public MineControls MineControls;
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
            MineControls.Setup();
        }
        else gameObject.SetActive(false);
        regenerateLevels.disappear();
    }
    public void noButton()
    {
        if (choiceText.text == "are you sure you want to stay a cat forever?")
        {
            gameObject.SetActive(false);
            MineControls.Setup();
        }
        choiceText.text = "are you sure you want to stay a cat forever?";
    }
}
