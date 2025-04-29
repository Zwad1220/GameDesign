using UnityEngine;

public class size : MonoBehaviour
{
    

public class SetResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, false); // false = windowed mode
    }
}
}
