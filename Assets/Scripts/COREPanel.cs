using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;
using Mirror;

public class COREPanel : NetworkBehaviour
{

    public GameObject PanelRoot;
    public SpriteRenderer PanelBG;
    public Button StartupButton;
    public Text StartupButtonText;
    public PLAYERManager PM;
    public COREManager CoreM;
    public GameManager GM;

    public GameObject FULLCOREPanel;
    public Button PL1Button;
    public Button PL2Button;
    public Button CL1Button;

    public bool FULLCOREPanelAct;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


/*    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PLAYER")
        {
            activePanel();
        }
    }
*/

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLAYER")
        {
            activePanel();
        }
    }


    public void activePanel()
    {
        if (CoreM.COREStatut == "off")
        {
            PanelRoot.active = true;
        }

        if (CoreM.COREStatut == "normal")
        {
            FULLCOREPanel.SetActive(true);
        }
    }

    public void disablePanel()
    {
        PanelRoot.active = false;
        print("lol");
        PM.canMove = true;
        InitCore();
        
    }

    [Command(requiresAuthority = false)]
    public void InitCore()
    {
        if (CoreM.COREStatut == "off")
        {
            CoreM.COREInit();
            StartupButton.colors = CoreM.initStat;
            StartupButtonText.text = "Initiating...";
        }
    }


    public void COREPanelInit()
    {

    }
}
