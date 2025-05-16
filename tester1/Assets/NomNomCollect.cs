using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class NomNomCollect : MonoBehaviour
{
    public  NomNomCount NomNomCount;
    //public GameObject NomNom;
    public GameObject GameWinScreen;
    public float count = 0;
    public Text NomNomnum;
    public AudioManager audioManager;

    public void Start()
    {
        NomNomCount.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NomNomCount.value++;
            audioManager.PlaySFX(audioManager.NomNomCollect);
            Destroy(gameObject);
            NomNomnum.text = NomNomCount.value.ToString();
            if (NomNomCount.value == 4)
            {
                GameWinScreen.SetActive(true);
            }
        }
    }
}
