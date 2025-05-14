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
        gameObject.SetActive(false);
        earthControls.Setup();
    }
    public void noButton()
    {
        choiceText.text = "you have no choice, press yes!";
    }
}
