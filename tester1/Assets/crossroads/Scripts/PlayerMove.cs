using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove;
    public bool active = false;
    public Rigidbody2D player;
    public GameObject Exit;
    Vector2 moveDirection;
    bool right = true;
    public completedGame GameComplete;
    public staticData staticData;
    public staticData2 staticData2;
    // Update is called once per frame
    private void Start()
    {
        canMove = true;
        if (staticData.value == true && staticData2.value == true)
        {
            GameComplete.Setup();
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
