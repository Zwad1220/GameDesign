using UnityEngine;

public class fail : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chaser"))
        {
            GameOverScreen.SetActive(true);
        }
    }
}
