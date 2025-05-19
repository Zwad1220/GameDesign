using UnityEngine;
using Pathfinding;

public class AIChase : MonoBehaviour
{
    //public GameObject player;
    //public int MoveSpeed;
    public fail fail;
    private AIPath path;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Transform player;
    public float distance;
    public PlayerMove playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 3)
        {
            playerMove.moveSpeed = 4;
            path.maxSpeed = MoveSpeed;
            path.destination = player.transform.position;
        }
        else { playerMove.moveSpeed = 2; }
    }
}
