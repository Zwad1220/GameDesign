using TMPro;
using UnityEngine;


public class regenerateLevels : MonoBehaviour
{
    public  GameObject airCat;
    public  GameObject fireCat;
    public  GameObject waterCat;
    public  GameObject earthCat;
    public  GameObject airLevelMove;
    public GameObject fireLevelMove;
    public GameObject waterLevelMove;
    public GameObject earthLevelMove;
    public  staticData staticData;
    public staticData2 staticData2;
    public staticData3 staticData3;
    public staticData4 staticData4;
    public PlayerMove playerMove;
    public GameObject exit;
    public TextMeshProUGUI choiceText;

    public void disappear()
    {
        choiceText.text = " ";
        playerMove.canMove = true;
        if (staticData.value == false)
        {
            airCat.SetActive(false);
            airLevelMove.SetActive(false); ;
        }
        if (staticData2.value == false)
        {
            fireCat.SetActive(false); ;
            fireLevelMove.SetActive(false); ;
        }
        if (staticData3.value == false)
        {
            earthCat.SetActive(false);
            earthLevelMove.SetActive(false);
        }
        if (staticData4.value == false)
        {
            waterCat.SetActive(false);
            waterLevelMove.SetActive(false);
        }
    }

    public void regenerateButton()
    {
        if (staticData.value == false)
        {
            airCat.SetActive(true);
            airLevelMove.SetActive(true); ;
        }
        if (staticData2.value == false)
        {
            fireCat.SetActive(true); ;
            fireLevelMove.SetActive(true); ;
        }
        if (staticData3.value == false)
        {
            earthCat.SetActive(true);
            earthLevelMove.SetActive(true);
        }
        if (staticData4.value == false)
        {
            waterCat.SetActive(true);
            waterLevelMove.SetActive(true);
        }
        playerMove.canMove = true;

        exit.SetActive(false);
    }
}
