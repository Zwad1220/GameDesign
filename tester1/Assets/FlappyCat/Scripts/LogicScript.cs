using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;
    public LevelMove LevelMove;
    public Text Lives;
    public GameObject RestartGame;
    public LivesScript LivesScript;
    public GameObject Exit;
  


    void Start()
    {
        Lives.text = LivesScript.playerLives.ToString();
    }
    public void ReduceLife()
    {
        LivesScript.playerLives--;

        Lives.text = LivesScript.playerLives.ToString();

        if (LivesScript.playerLives == 0)
        {
            RestartGame.SetActive(true);
        }
    }

    public void restartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Exit.SetActive(false);
        GameOverScreen.SetActive(true);
       
    }

    public void GameWon()
    {

        GameWonScreen.SetActive(true);
    }

    public void nextButton()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
