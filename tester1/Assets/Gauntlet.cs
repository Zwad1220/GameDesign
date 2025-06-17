using UnityEngine;
using UnityEngine.UI;


public class Gauntlet : MonoBehaviour
{
    public GameObject StoneText;
    public Text Objective;
    public AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.PlaySFX(audioManager.NomNomCollect);
        Destroy(gameObject);
        StoneText.SetActive(true);
        Objective.text = "Objective: Collect all elemental stones.";
    }
}
