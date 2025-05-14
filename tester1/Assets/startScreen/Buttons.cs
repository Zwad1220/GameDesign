using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public staticData staticData;
    public staticData2 staticData2;
    public staticData3 staticData3;
    public LivesScript LivesScript;
    private void Start()
    {
        staticData.value = false;
        staticData2.value = false;
        staticData3.value = false;
        LivesScript.playerLives = 9;
    }
    public void startButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitButton()
    {
        Application.Quit();

    }
}