using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainElevatorManaher : NetworkBehaviour
{

    public GameObject[] MainElevatorContent;
    public GameObject[] MainElevatorBlastDoors;
    public Vector3[] MainElevatorfloor;

    public string MainElevatorStatus = "IDLE";
    public string MainElevatorStat = "ONLINE";
    public int MainElevatorCurrentFloor = -3;

    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
