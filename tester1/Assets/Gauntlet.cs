using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gauntlet : MonoBehaviour
{
    public GameObject StoneText;
    public Text Objective;
    public int sceneBuildIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
