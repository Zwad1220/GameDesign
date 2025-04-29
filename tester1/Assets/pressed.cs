using UnityEngine;
using UnityEngine.SceneManagement;

public class pressed : MonoBehaviour
{
    public int sceneBuildIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void restart()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
