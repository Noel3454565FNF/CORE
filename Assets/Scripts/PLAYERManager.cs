using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERManager : MonoBehaviour
{

    public Rigidbody2D rgb;
    public float DirectionX;
    public float PlayerSpeed;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            DirectionX = Input.GetAxis("Horizontal");
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "COREpanel")
        {
            print("panel should open");
            canMove = false;
        }

    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            rgb.velocity = new Vector2(DirectionX * 6f, rgb.velocity.y);
        }
    }

    public void receivedAction(string message)
    {
        print("CORE STARTED");
    }
}
