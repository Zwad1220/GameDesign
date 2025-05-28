using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public int sceneBuildIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void pressed()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
