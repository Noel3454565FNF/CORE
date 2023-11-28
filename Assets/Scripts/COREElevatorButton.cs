using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class COREElevatorButton : MonoBehaviour
{

    public COREElevatorController CEC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLAYER")
        {
            Cmdlol();
        }
    }


    public void Cmdlol()
    {
        CEC.COREElevatorMoving();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
