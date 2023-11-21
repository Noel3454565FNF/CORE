using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public GameObject COREPanelThing;
    public PLAYERManager PM;


    //CORE things
    public Light2D CoreRoomLights1;
    public Light2D CoreRoomLights2;

    // Start is called before the first frame update
    void Start()
    {
        
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
        CoreRoomLights1.intensity = intensity;
        CoreRoomLights2.intensity = intensity;
    }
}