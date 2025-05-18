using UnityEngine;


public class LevelMove : MonoBehaviour
{

    public StartLevel StartLevel;
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
            if (staticData.value != true || staticData2.value != true|| staticData3.value != true || staticData4.value != true)
            {
                if (staticData.value == false)
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
                    StartLevel.Setup();
                }
                else
                {
                    PlayerMove movement = other.GetComponent<PlayerMove>();
                    movement.canMove = false;
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
