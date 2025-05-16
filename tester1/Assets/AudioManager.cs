using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip backround;
    public AudioClip backround1;
    public AudioClip backround2;
    public AudioClip backround3;
    public AudioClip backround4;
    public AudioClip death;
    public AudioClip NomNomCollect;
    public AudioClip pipeTouch;
    public AudioClip jump;
    //public AudioClip treeTouch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
