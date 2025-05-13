using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineStart : MonoBehaviour
{
    public TextMeshProUGUI choiceText;
    public MineControls MineControls;
    public void Setup()
    {
        gameObject.SetActive(true);


    }

    public void yesButton()
    {
        gameObject.SetActive(false);
        MineControls.Setup();
    }
    public void noButton()
    {
        choiceText.text = "you have no choice, press yes!";
    }
}
