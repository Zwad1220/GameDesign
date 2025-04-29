using UnityEngine;
using UnityEngine.SceneManagement;

public class returntocrossroads : MonoBehaviour
{
    public int sceneBuildIndex;
    public void nextButton()
    {

        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
