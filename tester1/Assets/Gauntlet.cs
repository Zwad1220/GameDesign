using UnityEngine;
using UnityEngine.UI;


public class Gauntlet : MonoBehaviour
{
    public GameObject StoneText;
    public Text Objective;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        StoneText.SetActive(true);
        Objective.text = "Objective: Collect all elemental stones.";
    }
}
