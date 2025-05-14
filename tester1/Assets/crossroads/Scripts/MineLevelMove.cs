using UnityEngine;

public class MineLevelMove : MonoBehaviour
{
    public MineStart MineStart;
    public MineComplete MineComplete;
    public completedGame GameComplete;
    public staticData3 staticData3;
    public staticData2 staticData2;
    public staticData staticData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (staticData.value != true || staticData2.value != true|| staticData3.value != true){

                if (staticData2.value == false)
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    MineStart.Setup();
                }
                else
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    MineComplete.Setup();
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