using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    public GameObject COREPanelThing;
    public PLAYERManager PM;
    public NetworkManager NetMan;

    public GameObject ServerCam;

    //CORE things
    public Light2D CoreRoomLights1;
    public Light2D CoreRoomLights2;
    public Light2D CoreRoomLights3;

    public string FacilityPower = "gen";

    public string TTS;

    public GameObject PanelCoreRoot;
    public GameObject PanelCoreRootComplete;
    public GameObject COREPaneling;
    public GameObject CORERoom;
    public GameObject CORESB; //Core Startup Button GameObject
    public Button CSB; //Core Startup Button Button
    public COREPanel COREP;
    public COREManager COREM;


    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            StartCoroutine(serverInit());
            //ServerCam.active = true;
        }
    }

    IEnumerator serverInit()
    {
        yield return new WaitForSeconds(0.5f);
        print("hey");
        PanelCoreRoot.SetActive(false);
        PanelCoreRootComplete.SetActive(false);
        if (CORESB == null)
        {
            CORESB = GameObject.Find("COREStartupButton");
            if (CORESB != null)
            {
                Button corep = (Button)CORESB.GetComponent(typeof(Button));
                CSB = corep;
            }
        }
        if (PanelCoreRoot == null)
        {
            PanelCoreRoot = GameObject.Find("COREpanelThing");
            if (PanelCoreRoot != null)
            {

            }

        }
        if (PanelCoreRootComplete == null)
        {
            PanelCoreRootComplete = GameObject.Find("COREpanelComplete");
            if (PanelCoreRootComplete != null)
            {
            }
        }
        if (COREPaneling == null)
        {
            COREPaneling = GameObject.Find("COREPanel");
            if (COREPaneling != null)
            {
                COREPanel coreP = (COREPanel)COREPaneling.GetComponent(typeof(COREPanel));
                COREP = coreP;
            }
        }
        if (CORERoom == null)
        {
            CORERoom = GameObject.Find("CORE room");
            if (CORERoom != null)
            {
                COREManager coreM = (COREManager)CORERoom.GetComponent(typeof(COREManager));
                COREM = coreM;
            }
        }

        afterServerInit();
    }

    public void afterServerInit()
    {
        PanelCoreRoot.SetActive(false);
        PanelCoreRootComplete.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel(string panel, bool state)
    {
        if (panel == "COREpanel")
        {
            COREPanelThing.SetActive(state);
            PM.canMove = !state;
        }
    }


    public void condtrolMove(bool can)
    {
        PM.canMove = can;
    }


    public void COREROOMLights(float intensity)
    {
/*        CoreRoomLights1.intensity = intensity;
        CoreRoomLights2.intensity = intensity;
*/        CoreRoomLights3.intensity = intensity;
    }
    
}