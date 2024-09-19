using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BlastDoorsInfo : MonoBehaviour
{

    public Vector3 BlastDoorsClosedPos;
    public Vector3 BlastDoorsClosedSca;

    public Vector3 BlastDoorsOpenPos;
    public Vector3 BlastDoorsOpenSca;

    public string BlastDoorStatus = "ONLINE";
    public string BlastDoorStat = "OPEN";

    public uint BlastDoorID = 0;

    private void Start()
    {
        BlastDoorID = GameObject.Find("GameManager").GetComponent<GameManager>().BlastDoorIDReturnerforregistry();
    }

    public void closeBlastDoor()
    {
        if (BlastDoorStatus != "OVERRIDE LOCK" || BlastDoorStatus != "DEFAULT" || BlastDoorStatus != "ERROR")
        {
            if (BlastDoorStat != "CLOSE" || BlastDoorStat != "CLOSING" || BlastDoorStat != "OPENING")
            {
                BlastDoorStat = "CLOSING";
                gameObject.transform.LeanMove(BlastDoorsClosedPos, 5f).setId(BlastDoorID, BlastDoorID);
                gameObject.transform.LeanScale(BlastDoorsClosedSca, 5f).setId(BlastDoorID, BlastDoorID).setOnComplete(hewo);
            }
        }
    }




    public void StopBlastDoor()
    {
        int lmao = (int)BlastDoorID;
        LeanTween.pause(lmao);
    }

    public void hewo()
    {
        BlastDoorStat = "CLOSE";
        print(gameObject.name + " is now " +  BlastDoorStat);
    }
}
