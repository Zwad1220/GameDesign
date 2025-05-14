using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    public bool complete;
    private bool hasCollided = false;
    public bool active = false;
    public GameObject Exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        complete = false;
        staticData.value = complete;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                Exit.SetActive(true);
                active = true;
            }
            else
            {
                active = false;
                Exit.SetActive(false);
            }
    }

        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
        {
            MyRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided) return;

        if (collision.CompareTag("GameController"))
        {
            hasCollided = true;
            logic.GameOver();
            BirdIsAlive = false;
            logic.ReduceLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NomNom"))
        {
            complete = true;
            staticData.value = complete;
            logic.GameWon();
            GameObject.Destroy(collision.gameObject);
            BirdIsAlive = true;
        }
    }
}