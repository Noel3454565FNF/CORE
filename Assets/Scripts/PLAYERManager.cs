using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PLAYERManager : MonoBehaviour
{

    public Rigidbody2D rgb;
    public float DirectionX;
    public float PlayerSpeed;
    public bool canMove = true;
    public bool COREPanelState;
    public bool FullCorePanel = false;
    public bool FullCorePanelState;
    public bool CorePanelInCollision = false;

    public GameObject PanelCoreRoot;
    public GameObject PanelCoreRootComplete;
    public GameObject COREPaneling;
    public GameObject CORERoom;
    public GameObject CORESB; //Core Startup Button GameObject
    Button CSB; //Core Startup Button Button
    COREPanel COREP;
    COREManager COREM;

    GameManager GM;
    GameObject GMO;

    Camera mainCam;


    void Awake()
    {
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        if (GM == null)
        {
            GMO = GameObject.Find("GameManager");
            if (GMO != null)
            {
                GameManager gmn = (GameManager)GMO.GetComponent(typeof(GameManager));
                GM = gmn;
                GM.CSB = CSB;
                CSB.onClick.AddListener(CSBClick);
            }

        }
    }
    private void CSBClick()
    {
        canMove = true;
        COREPanelState = false;
        PanelCoreRoot.SetActive(false);
        CorePanelInCollision = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (COREM != null)
        {
            if (COREM.COREStatut == "normal")
            {
                FullCorePanel = true;
            }
        }
        if (canMove == true)
        {
            DirectionX = Input.GetAxis("Horizontal");
        }



        if (Input.GetKeyDown(KeyCode.X))
        {
                canMove = true;
            if (COREPanelState == true)
            {
                COREPanelState = false;
                PanelCoreRoot.SetActive(false);
                CorePanelInCollision = false;

            }
            if (FullCorePanelState == true)
            {
                FullCorePanelState = false;
                PanelCoreRootComplete.SetActive(false);
            }
            PanelCoreRoot.SetActive(false);
            PanelCoreRootComplete.SetActive(false);

            //COREPanelState = false;
            //FullCorePanelState = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        
        if (collision.name == "COREPanel")
        {
            print("llol1");
            CorePanelInCollision = true;
            StartCoroutine(COREPanelLol());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "COREPanel")
        {
            CorePanelInCollision = false;
        }

    }

    public void closePanel(GameObject panel)
    {
        canMove = true;
        panel.SetActive(false);
    }




    public void changeMove(bool ya)
    {
        canMove = ya;
        this.canMove = ya;
    }

/*    public void OpenPanel(string panel, bool state)
    {
        panel.transform.gameObject.SetActive(state);
        print(panel.gameObject);
        panel.SetActive(state);
        canMove = !state;
        
    }
*/

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            rgb.velocity = new Vector2(DirectionX * 6f, rgb.velocity.y);
        }
    }

    public void receivedAction(string message)
    {
        print("CORE STARTED");
        canMove = true;
    }



    public void CALLFORF(string func)
    {
        if (func == "FULLCOREPANEL")
        {
            BroadcastMessage("FULLCOREPANEL");
        }
    }


    public void FULLCOREPANEL()
    {
        FullCorePanel = true;
    }



    IEnumerator COREPanelLol()
    {
        print("llol2");
        yield return new WaitForSeconds(0.1f);
        if (PanelCoreRoot != null && CorePanelInCollision == true)
        {
            COREPanelState = true;
            print("llol3");
            canMove = false;
            rgb.velocity = Vector2.zero;
            COREP.activePanel();
        }
        if (GameObject.Find("COREpanelComplete"))
        {
            COREPanelState = true;
            print("llol4");
            FullCorePanelState = true;
            canMove = false;
            rgb.velocity = Vector2.zero;
        }

    }

}


public class PLAYERNet : NetworkBehaviour
{

    public PLAYERManager PM;
    public void FULLCOREPANEL()
    {
       PM.FullCorePanel = true;
    }

    public override void OnStartLocalPlayer()
    {
        print("ll");
        Camera.main.transform.SetParent(transform);
    }

    }