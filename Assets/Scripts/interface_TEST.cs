using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class interfaceTEST : NetworkBehaviour
{
    public PLAYERManager PM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  
    public void activePanel()
    {
        if (PM.COREM.COREStatut == "off" && isLocalPlayer)
        {
            PM.PanelCoreRoot.SetActive(true);
        }

        if (PM.COREM.COREStatut == "normal" && isLocalPlayer)
        {
            PM.PanelCoreRootComplete.SetActive(true);
        }
    }

}
