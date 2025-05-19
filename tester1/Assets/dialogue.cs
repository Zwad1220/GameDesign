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
    public GameObject buttonY;
    public GameObject buttonN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        text.text = string.Empty;
        startSpeech();
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text == words[index])
        {
            buttonY.SetActive(true);
            buttonN.SetActive(true);
        }
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
