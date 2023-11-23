using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class COREElevatorController : NetworkBehaviour
{
    public GameObject COREElevator;
    public SpriteRenderer COREElebatorSPR;
    public Vector3[] COREElevatorPos;
    public string COREElevatorState;
    public GameManager GM;
    public GameObject CEC;
    public bool canMove;
    public float MoveTime;
    public float WaitTime;
    public Color[] COREElevatorColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator COREElevatorRaise()
    {
        if (GM.FacilityPower != "PO")
        {
            if (COREElevatorState == "up")
            {
                COREElebatorSPR.color = COREElevatorColor[0];
                canMove = false;
                COREElevator.transform.LeanMoveLocal(COREElevatorPos[0], MoveTime);
                yield return new WaitForSeconds(MoveTime);
                COREElevatorState = "down";
                yield return new WaitForSeconds(WaitTime);
                canMove = true;
                COREElebatorSPR.color = COREElevatorColor[1];
            }
            if (COREElevatorState == "down")
            {
                COREElebatorSPR.color = COREElevatorColor[0];
                canMove = false;
                COREElevator.transform.LeanMoveLocal(COREElevatorPos[1], MoveTime);
                yield return new WaitForSeconds(MoveTime);
                COREElevatorState = "up";
                yield return new WaitForSeconds(WaitTime);
                canMove = true;
                COREElebatorSPR.color = COREElevatorColor[1];
            }
            StopCoroutine(COREElevatorRaise());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == CEC && canMove == true)
        {
            COREElevatorMoving();
        }

    }

    [Command(requiresAuthority = false)]
    public void COREElevatorMoving()
    {
        StartCoroutine(COREElevatorRaise());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
