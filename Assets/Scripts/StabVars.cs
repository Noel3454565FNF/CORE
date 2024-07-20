using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StabVars : NetworkBehaviour
{
    
    public Vector3[] Stab1; 
    public Vector3[] Stab2;
    public Vector3[] Stab3;
    public Vector3[] Stab4;
    //1 array: offline
    //2 array: online



    public Vector3[] STABSPW12;
    public Vector3[] STABSPW34;


    public GameObject[] STABSGM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initSTABS()
    {
        STABSGM[1].transform.position = Stab1[1];
        STABSGM[1].transform.localScale = STABSPW12[1];
        STABSGM[2].transform.position = Stab2[1];
        STABSGM[2].transform.localScale = STABSPW12[1];
        STABSGM[3].transform.position = Stab3[1];
        STABSGM[3].transform.localScale = STABSPW34[1];
        STABSGM[4].transform.position = Stab4[1];
        STABSGM[4].transform.localScale = STABSPW34[1];
    }
}
