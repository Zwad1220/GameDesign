using UnityEngine;


public class WaterLevelMove : MonoBehaviour
{

    public WaterStart WaterStart;
    public LockDoor lockDoor;
    public staticData staticData;
    public staticData2 staticData2;
    public staticData3 staticData3;
    public staticData4 staticData4;
    public completedGame GameComplete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (staticData.value != true || staticData2.value != true || staticData3.value != true || staticData4.value != true)
            {
                if (staticData.value == false)
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    WaterStart.Setup();
                }
                else
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    lockDoor.Setup();
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

