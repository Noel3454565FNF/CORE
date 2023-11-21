using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;

public class COREPanel : MonoBehaviour
{

    public GameObject PanelRoot;
    public SpriteRenderer PanelBG;
    public Button StartupButton;
    public Text StartupButtonText;
    public PLAYERManager PM;
    public COREManager CoreM;

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
        PanelRoot.active = true;
        PM.canMove = false;
    }

    public void disablePanel()
    {
        PanelRoot.active = false;
        print("lol");
        PM.canMove = true;
        InitCore();
        
    }


    public void InitCore()
    {
        CoreM.COREInit();
        StartupButton.colors = CoreM.initStat;
        StartupButtonText.text = "Initiating...";
    }
}
