using UnityEngine;

public class EarthLevelMove : MonoBehaviour
{
    public WrestleStart wrestleStart;
    public GameObject earthDeny;
    public completedGame GameComplete;
    public staticData3 staticData3;
    public staticData2 staticData2;
    public staticData staticData;
    public staticData4 staticData4;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (staticData.value != true || staticData2.value != true||staticData3.value != true || staticData4.value != true)
            {

                if (staticData3.value == false)
                {
                    if (staticData.value == true || staticData2.value == true || staticData4.value == true)
                    {
                        PlayerMove movement = other.GetComponent<PlayerMove>();
                        movement.canMove = false;
                        wrestleStart.Setup();
                    }
                    else
                    {
                        PlayerMove movement = other.GetComponent<PlayerMove>();
                        movement.canMove = false;
                        earthDeny.SetActive(true);
                    }
                }
              
            }
            else
            {
                PlayerMove movement = other.GetComponent<PlayerMove>();
                movement.canMove = false;
                GameComplete.Setup();
            }
        }

    }
}
