using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class COREElevatorController : MonoBehaviour
{
    public GameObject COREElevator;
    public SpriteRenderer COREElebatorSPR;
    public Vector3[] COREElevatorPos;
    public string COREElevatorState = "down";
    public GameManager GM;
    public GameObject CEC;
    public bool canMove = true;
    public float MoveTime;
    public float WaitTime;
    public Color[] COREElevatorColor;
    public SpriteRenderer SecondaryButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator COREElevatorRaiseUp()
    {
        if (GM.FacilityPower != "PO")
        {
            if (COREElevatorState == "up")
            {
                COREElebatorSPR.color = COREElevatorColor[0];
                SecondaryButton.color = COREElevatorColor[0];
                canMove = false;
                COREElevator.transform.LeanMoveLocal(COREElevatorPos[0], MoveTime);
                yield return new WaitForSeconds(MoveTime);
                COREElevatorState = "down";
                yield return new WaitForSeconds(WaitTime);
                canMove = true;
                COREElebatorSPR.color = COREElevatorColor[1];
                SecondaryButton.color = COREElevatorColor[1];
                StopCoroutine(COREElevatorRaiseUp());
            }
        }
    }
    IEnumerator COREElevatorRaiseDown()
    {
        if (GM.FacilityPower != "PO")
        {
            if (COREElevatorState == "down")
            {
                COREElebatorSPR.color = COREElevatorColor[0];
                SecondaryButton.color = COREElevatorColor[0];
                canMove = false;
                COREElevator.transform.LeanMoveLocal(COREElevatorPos[1], MoveTime);
                yield return new WaitForSeconds(MoveTime);
                COREElevatorState = "up";
                yield return new WaitForSeconds(WaitTime);
                canMove = true;
                COREElebatorSPR.color = COREElevatorColor[1];
                SecondaryButton.color = COREElevatorColor[1];
                StopCoroutine(COREElevatorRaiseDown());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PLAYER" && canMove == true)
        {
            COREElevatorMoving();
        }

    }

    public void COREElevatorMoving()
    {
        if (COREElevatorState == "up")
        {
            StartCoroutine(COREElevatorRaiseUp());
        }

        if (COREElevatorState == "down")
        {
            StartCoroutine(COREElevatorRaiseDown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
