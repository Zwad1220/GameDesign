using System.Collections;
using Pathfinding;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] words ;
    public float speed ;
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = string.Empty;
        startSpeech();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void startSpeech()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in words[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }
    }


}
