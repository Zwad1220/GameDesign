using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fail : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Player;
    public AudioManager audioManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chaser"))
        {
            audioManager.PlaySFX(audioManager.death);
            Player.SetActive(false);
            GameOverScreen.SetActive(true);
        }
    }
    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
