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
            path.maxSpeed = MoveSpeed;
            path.destination = player.transform.position;
        }
        /*Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 2.5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }*/
    }
}
