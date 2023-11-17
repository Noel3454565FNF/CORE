using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject COREPanelThing;
    public PLAYERManager PM;

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
}
