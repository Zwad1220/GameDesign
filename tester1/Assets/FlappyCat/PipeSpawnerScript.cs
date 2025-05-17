using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject NomNom;
    public GameObject Ground;
    public double spawnRate = 2.5;
    private float timer = 0;
    private float timer2 = 0;
    public float heightOffset = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (timer2 == 30)
        {
            Instantiate(Ground, new Vector3(transform.position.x, -13, 0), transform.rotation);
            timer2++;
        }
        else if (timer2 == 31) //31
        {
            Instantiate(NomNom, new Vector3(transform.position.x, 0, 0), transform.rotation);
            timer2++;
        }
        else if (timer2 < 30)
        {
            spawnPipe();
            timer = 0;
            timer2++;
        }
        else
        {
            Instantiate(Ground, new Vector3(transform.position.x, -13, 0), transform.rotation);
        }
    }
    void spawnPipe()
    {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }


}
