using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainElevatorManaher : NetworkBehaviour
{

    public GameObject[] MainElevatorContent;
    public GameObject[] MainElevatorBlastDoors;
    private BlastDoorsInfo[] MainElevatorBlastDoorsSYS;
    public Vector3[] MainElevatorfloor;

    public string MainElevatorStatus = "IDLE";
    public string MainElevatorStat = "ONLINE";
    public int MainElevatorCurrentFloor = -3;

    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        MainElevatorBlastDoorsSYS.Initialize();
        int attempt = -1;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        foreach(GameObject L in  MainElevatorBlastDoors)
        {
            if (attempt <= 0)
            {
                attempt += 1;
            }
            else if (attempt == -1)
            {
                attempt = 0;
            }
           MainElevatorBlastDoorsSYS[attempt] = L.GetComponent<BlastDoorsInfo>();
        }
    }



    public void GonnaMoveMainElev(int floor)
    {
        int diff = diffrence(floor, MainElevatorCurrentFloor);
    }



    public int diffrence(int num1, int num2)
    {
        int cout;

        cout = Mathf.Max(num2, num1) - Mathf.Min(num1, num2);

        return cout;
    }
}
