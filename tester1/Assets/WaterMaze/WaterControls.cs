using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterControls : MonoBehaviour
{
    public int sceneBuildIndex;
    public void Setup()
    {
        gameObject.SetActive(true);

    }

    public void continueButton()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
