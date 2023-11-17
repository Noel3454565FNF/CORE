using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERManager : MonoBehaviour
{

    public Rigidbody2D rgb;
    public float DirectionX;
    public float PlayerSpeed;
    public bool canMove;


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
            print("moved");
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "COREPanel")
        {
            canMove = false;
            rgb.velocity = Vector2.zero;
            
        }

    }



    public void closePanel(GameObject panel)
    {
        canMove = true;
        panel.SetActive(false);
    }




    public void changeMove(bool ya)
    {
        canMove = ya;
        this.canMove = ya;
    }

/*    public void OpenPanel(string panel, bool state)
    {
        panel.transform.gameObject.SetActive(state);
        print(panel.gameObject);
        panel.SetActive(state);
        canMove = !state;
        
    }
*/

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            rgb.velocity = new Vector2(DirectionX * 6f, rgb.velocity.y);
            print("fixed");
        }
    }

    public void receivedAction(string message)
    {
        print("CORE STARTED");
        canMove = true;
    }
}
