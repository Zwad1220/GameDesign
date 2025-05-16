using UnityEngine;

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
            GameOverScreen.SetActive(true);
        }
    }
}
