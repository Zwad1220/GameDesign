using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class NomNomCollect : MonoBehaviour
{
    public GameObject NomNom;
    public float count;
    public Text NomNomCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        Destroy(NomNom);
        NomNomCount.text = count.ToString();
    }
}
