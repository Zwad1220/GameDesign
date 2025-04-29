using UnityEngine;
using UnityEngine.SceneManagement;
public class startScreen : MonoBehaviour
{
    public void doneButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
