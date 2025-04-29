using UnityEngine;


public class LevelMove : MonoBehaviour
{

    public StartLevel StartLevel;
    public CompletedLevel CompletedLevel;
    public staticData staticData;
    public staticData2 staticData2;
    public completedGame GameComplete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (staticData.value != true || staticData2.value != true)
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
                    CompletedLevel.Setup();
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
