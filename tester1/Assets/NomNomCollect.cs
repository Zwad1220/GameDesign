using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class NomNomCollect : MonoBehaviour
{
    public GameObject NomNom;
    public GameObject GameWinScreen;
    public float count = 0;
    public Text NomNomCount;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        audioManager.PlaySFX(audioManager.NomNomCollect);
        Destroy(NomNom);
        NomNomCount.text = count.ToString();
        if (count == 4)
        {
            GameWinScreen.SetActive(true);
        }
    }
}
