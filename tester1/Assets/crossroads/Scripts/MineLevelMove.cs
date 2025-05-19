using UnityEngine;

public class MineLevelMove : MonoBehaviour
{
    public MineStart MineStart;

    public completedGame GameComplete;
    public staticData4 staticData4;
    public staticData3 staticData3;
    public staticData2 staticData2;
    public staticData staticData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (staticData.value != true || staticData2.value != true|| staticData3.value != true || staticData4.value != true)
            {

                if (staticData2.value == false)
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    MineStart.Setup();
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