using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text Objective;
    public GameObject gauntlet;
    public float moveSpeed;
    public bool canMove;
    public bool active = false;
    public Rigidbody2D player;
    public GameObject Exit;
    Vector2 moveDirection;
    bool right = true;
    public GameObject airCat;
    public GameObject fireCat;
    public GameObject waterCat;
    public GameObject earthCat;
    public GameObject airLevelMove;
    public GameObject fireLevelMove;
    public GameObject waterLevelMove;
    public GameObject earthLevelMove;
    public GameObject airStone;
    public GameObject waterStone;
    public GameObject fireStone;
    public GameObject earthStone;
    public completedGame GameComplete;
    public staticData staticData;
    public staticData2 staticData2;
    public staticData3 staticData3;
    public staticData4 staticData4;
    // Update is called once per frame
    private void Start()
    {
        canMove = true;
        if (staticData.value == true)
        {
            Destroy(airCat);
            Destroy(airLevelMove);
            airStone.SetActive(true);
        }
        if (staticData2.value == true)
        {
            Destroy(fireCat);
            Destroy(fireLevelMove);
            fireStone.SetActive(true);
        }
        if (staticData3.value == true)
        {
            Destroy(earthCat);
            Destroy(earthLevelMove);
            earthStone.SetActive(true);
        }
        if (staticData4.value == true)
        {
            Destroy(waterCat);
            Destroy(waterLevelMove);
            waterStone.SetActive(true);
        }
        if (staticData.value == true && staticData2.value == true && staticData3.value == true && staticData4.value == true)
        {
            Objective.text = "Objective: Locate the gauntlet of humanity.";
            gauntlet.SetActive(true);
        }
    }
    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                Exit.SetActive(true);
                active = true;
                canMove = false;
            }
            else
            {
                active = false;
                Exit.SetActive(false);
                canMove = true;
            }
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            moveDirection = new Vector2(moveX, moveY).normalized;

            if (moveX > 0 && !right)
            {
                flip();
            }
            if (moveX < 0 && right)
            {
                flip();
            }
        }
        
    }

    void Move()
    {
            player.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
        right = !right;
    }

}
