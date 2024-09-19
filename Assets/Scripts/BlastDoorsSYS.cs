using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDoorsSYS : MonoBehaviour
{

    public GameObject[] COREBD;
    public GameManager GM;

    public Action[] L;
    // Start is called before the first frame update
    void Start()
    {
        GM = gameObject.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void COREROOMLOCKDOWN()
    {
        if (GM.FacilityPower != "blackout" || GM.FacilityPower != "no power")
        {
            foreach (GameObject go in COREBD)
            {
                go.GetComponent<BlastDoorsInfo>().closeBlastDoor();
            }
        }
    }
}
