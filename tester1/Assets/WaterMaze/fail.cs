using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fail : MonoBehaviour
{
    public LivesScript LivesScript;
    public GameObject GameOverScreen;
    public GameObject Player;
    public Text lives;
    public GameObject RestartGame;

    public AudioManager audioManager;

    private void Start()
    {
        lives.text = LivesScript.playerLives.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chaser"))
        {
            audioManager.PlaySFX(audioManager.death);
            Player.SetActive(false);
            ReduceLife();
            GameOverScreen.SetActive(true);
        }
    }

    public void ReduceLife()
    {
        LivesScript.playerLives--;

        lives.text = LivesScript.playerLives.ToString();

        if (LivesScript.playerLives == 0)
        {
            RestartGame.SetActive(true);
        }
    }
    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
