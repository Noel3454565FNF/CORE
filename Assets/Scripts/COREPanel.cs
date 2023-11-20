using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COREPanel : MonoBehaviour
{

    public GameObject PanelRoot;
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
        CoreM.StartCoroutine(CoreM.CORE());
    }

}
