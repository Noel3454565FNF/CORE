using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class COREManager : NetworkBehaviour
{

    public GameManager GM;
    public GameManagerNet GMN;
    public COREPanel COREP;
    public PLAYERManager PM;
    public SpriteRenderer COREColor;
    public ScreenFlash screenFlash;
    public StabVars stabVars;

    public Light2D CORELight;
    public SpriteRenderer TV;
    public TextMeshPro TVText;
    public GameObject CORE;

    public GameObject PL1;
    public GameObject PL2;
    public GameObject CL1;

    public Text PL1Text;
    public Text PL2Text;
    public Text CL1Text;

    public Slider PL1Slide;
    public Slider PL2Slide;
    public Slider CL1Slide;

    public GameObject sf1;
    public GameObject sf2;

    [SyncVar]
    public string CL1Power;
    [SyncVar]
    public string PL1Power;
    [SyncVar]
    public string PL2Power;
    public Vector3[] PLPower;
    public Vector3[] CLPower;

        
    

    [SyncVar]
    public bool COREFailedStart = false;
    [SyncVar]
    public bool COREUnstableState = false;
    [SyncVar]
    public bool COREMeltdownEnter = false;
    [SyncVar]
    public bool COREMeltdown = false;
    [SyncVar]
    public bool COREFreezedownEnter = false;
    [SyncVar]
    public bool COREFreezedown = false;
    [SyncVar]
    public bool COREBlackHole = false;

    [SyncVar]
    public bool COREInEvent = false;
    [SyncVar]
    public string COREEventName;
    [SyncVar]
    public int tempFactor = 1;

    [SyncVar]
    public Color redStat;
    [SyncVar]
    public Color yellowStat;
    [SyncVar]

    public Color greenStat;
    [SyncVar]

    public Color offStat;
    [SyncVar]

    public ColorBlock initStat;
    [SyncVar]

    public string COREStatut;
    [SyncVar]

    public int CORETemp;
    public NetworkWriter lol;




    // Start is called before the first frame update
    void Start()
    {
        TV.color = offStat;
        COREColor.color = offStat;
        COREStatut = "off";
        CORETemp = 100;
        CORELight.color = offStat;
        PL1Slide.onValueChanged.AddListener(PL1SliderValueChanged);
        PL2Slide.onValueChanged.AddListener(PL2SliderValueChanged);
        CL1Slide.onValueChanged.AddListener(CL1SliderValueChanged);     

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            tempFactor = -100;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject.Instantiate(sf2);
        }
    }

    [ClientRpc]
    public void COREInit()
    {
        StartCoroutine(COREInite());
/*        if(isServer == true)
        {
            COREInitSync();
        }
*/        print("core Init");
    }


/*    [TargetRpc]
    public void COREInitSync()
    {
        StartCoroutine(COREInite());
    }
*/
    IEnumerator COREInite()
    {
        COREStatut = "init";
        yield return new WaitForSeconds(1f);
        GM.COREROOMLights(0.23f);
        CORELight.intensity = 1f;
        print("core startup 1");
        yield return new WaitForSeconds(3f);
        if (GMN.COREStartFailureChance == true)
        {
            print("core failed Init");
            COREFailedStart = true;
            TV.color = Color.yellow;
            CORELight.color = Color.yellow;
            COREP.StartupButtonText.text = "FAILED";
            COREStatut = "failed";
        }
        else
        {
            print("core success Init");
            COREFailedStart = false;
            COREP.StartupButtonText.text = "SUCCESS";
            StartCoroutine(COREStartup());
        }
        StopCoroutine(COREInite());

    }


    IEnumerator COREStartup()
    {
        CORE.transform.LeanMoveLocalY(8.5f, 2);
        yield return new WaitForSeconds(2f);
        COREP.StartupButtonText.text = "Init Power Laser 1...";
        yield return new WaitForSeconds(1.5f);
        PL1Power = "medium";
        PL1.transform.localScale = PLPower[2];
        COREP.StartupButtonText.text = "Init Power Laser 2...";
        yield return new WaitForSeconds(1.5f);
        PL2Power = "medium";
        PL2.transform.localScale = PLPower[2];
        COREP.StartupButtonText.text = "Init Cooling Laser 1...";
        yield return new WaitForSeconds(2f);
        CL1Power = "actif";
        CL1.transform.localScale = CLPower[1];
        yield return new WaitForSeconds(0.5f);
        stabVars.initSTABS();
        screenFlash.startupflash();
        GM.COREROOMLights(1f);
        TV.color = Color.green;
        COREStatut = "normal";
        COREP.StartupButton.gameObject.SetActive(false);
        COREP.StartupButtonText.gameObject.SetActive(false);
        //COREP.activePanel();
        CORETemp = 1500;
        TVText.text = CORETemp+"C°";
        StartCoroutine(CORETempUpdate());



    }


    [Command]
    public void CORETepUpdateCall()
    {

    }

    IEnumerator CORETempUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        if (isServer == true)
        {
            int nextT = tempFactor;
            if (COREStatut == "normal")
            {
                if (PL1Power == "offline" || PL1Power == "ERROR")
                {
                    nextT = nextT + 0;
                }
                if (PL1Power == "minimum")
                {
                    nextT = nextT + 1;
                }
                if (PL1Power == "medium")
                {
                    nextT = nextT + 4;
                }
                if (PL1Power == "maximum")
                {
                    nextT = nextT + 7;
                }

                if (PL2Power == "offline" || PL2Power == "ERROR")
                {
                    nextT = nextT + 0;
                }
                if (PL2Power == "minimum")
                {
                    nextT = nextT + 1;
                }
                if (PL2Power == "medium")
                {
                    nextT = nextT + 4;
                }
                if (PL2Power == "maximum")
                {
                    nextT = nextT + 7;
                }

                if(CL1Power == "offline" || CL1Power == "ERROR")
                {
                    nextT = nextT - 0;
                }
                if (CL1Power == "actif")
                {
                    nextT = nextT - 10;
                }
                CORETemp += nextT;
                TVText.text = CORETemp + "C°";
                CORETempUpdateClient(nextT);
                MainCoreEventChecker();
                print("nextT applied "+nextT+" and "+CORETemp+" core statut is "+COREStatut);
                nextT = 0;
                StartCoroutine(CORETempUpdate());

            }

        }

    }

    [ClientRpc]
    public void CORETempUpdateClient(int tempNexT)
    {
        TVText.text = CORETemp + "C°";
        print(tempNexT);
    }



    public void PL1SliderValueChanged(float haha)
    {
        PL1Slide.value = haha;
        //float haha = tempPL1Var;
        if (haha == 1 && PL1Power != "ERROR")
        {
            PL1Power = "minimum";
        }
        if (haha == 2 && PL1Power != "ERROR")
        {
            PL1Power = "medium";
        }
        if (haha == 3 && PL1Power != "ERROR")
        {
            PL1Power = "maximum";
        }
        if (isClient == true && PL1Power != "ERROR")
        {
            PL1SliderValueChangedToServer(haha);
        }
        if (isServer && PL1Power != "ERROR")
        {
            PL1SliderValueChangedToClient(haha);
        }
        print(PL1Power);
    }

    [Command(requiresAuthority = false)]
    public void PL1SliderValueChangedToServer(float haha)
    {
        PL1Slide.value = haha;
    }
    [ClientRpc]
    public void PL1SliderValueChangedToClient(float haha)
    {
        PL1Slide.value = haha;
    }

    public void PL2SliderValueChanged(float haha)
    {
        PL2Slide.value = haha;
        if (haha == 1 && PL2Power != "ERROR")
        {
            PL2Power = "minimum";
        }
        if (haha == 2 && PL2Power != "ERROR")
        {
            PL2Power = "medium";
        }
        if (haha == 3 && PL2Power != "ERROR")
        {
            PL2Power = "maximum";
        }

        if (isClient == true && PL2Power != "ERROR")
        {
            PL2SliderValueChangedToServer(haha);
        }
        if (isServer && PL2Power != "ERROR")
        {
            PL2SliderValueChangedToClient(haha);
        }
        print(PL2Power);
    }

    [Command(requiresAuthority = false)]
    public void PL2SliderValueChangedToServer(float haha)
    {
        PL2Slide.value = haha;
    }
    [ClientRpc]
    public void PL2SliderValueChangedToClient(float haha)
    {
        PL2Slide.value = haha;
    }


    public void CL1SliderValueChanged(float haha)
    {
        CL1Slide.value = haha;
        if (haha == 0 && CL1Power != "ERROR")
        {
            CL1Power = "offline";
        }
        if (haha == 1 && CL1Power != "ERROR")
        {
            CL1Power = "actif";
        }
        if (isClient == true && CL1Power != "ERROR")
        {
            CL1SliderValueChangedToServer(haha);
        }
        if (isServer && CL1Power != "ERROR")
        {
            CL1SliderValueChangedToClient(haha);
        }
        print(CL1Power);
    }

    [Command(requiresAuthority = false)]
    public void CL1SliderValueChangedToServer(float haha)
    {
        CL1Slide.value = haha;
    }
    [ClientRpc]
    public void CL1SliderValueChangedToClient(float haha)
    {
        CL1Slide.value = haha;
    }



    //CORE Events
    public void MainCoreEventChecker()
    {
        if (isServer)
        {
            if (CORETemp >= 3000 && COREUnstableState == false && COREInEvent == false)
            {
                COREUnstableState = true;
                TV.color = Color.yellow;
                tempFactor = 5;
                COREEnterHighTempUnstableState();
                print("core is now unstable");
            }
            if (CORETemp <= 2700 && COREUnstableState == true && COREInEvent == false)
            {
                COREUnstableState = false;
                TV.color = Color.green;
                tempFactor = 1;
                COREExitHighTempUnstableState();
                print("not anymore");
            }


            if (CORETemp <= 300 && COREUnstableState == false && COREInEvent == false)
            {
                COREUnstableState = true;
                TV.color = Color.yellow;
                tempFactor = -5;
                COREEnterLowTempUnstableState();
            }
            if (CORETemp >= 700 && COREUnstableState == true && COREInEvent == false)
            {
                COREUnstableState = false;
                TV.color = Color.green;
                tempFactor = 1;
                COREExitLowTempUnstableState();
            }
            if (CORETemp <= -100 && COREUnstableState == true && COREInEvent == false)
            {
                COREEnterFreezeDown();
                StartCoroutine(COREFreezeDownEnterCour());
            }
        }
    }

    IEnumerator COREFreezeDownEnterCour()
    {
        COREInEvent = true;
        COREEventName = "FreezeDown";
        tempFactor = -19;
        COREColor.gameObject.LeanColor(Color.cyan, 10f);
        CL1Text.text = "ERROR: Unresponsive!";
        CL1Power = "ERROR";
        yield return new WaitForSeconds(7f);
        tempFactor += -22;
        PL1Text.text = "ERROR: NO POWER!";
        PL2Text.text = "ERROR: NO POWER!";
        PL1Power = "ERROR";
        PL2Power = "ERROR";
        PL1.LeanScale(PLPower[0], 5f);
        PL2.LeanScale(PLPower[0], 5f);
        yield return new WaitForSeconds(10f);
        GameObject.Instantiate(sf1);
        COREBlackHole = true;
        yield return new WaitForSeconds(5f);
        COREColor.gameObject.LeanColor(Color.blue, 10f);
        yield return new WaitForSeconds(6f);
        COREColor.gameObject.LeanColor(Color.black, 10f);
        GameObject.Instantiate(sf2);


    }
    /*    IEnumerator MainCoreEventCheckerCooldown()
        {
            yield return new WaitForSeconds(0.1f);
            MainCoreEventChecker();
        }
    */


    //CORE Events for clients
    [ClientRpc]
    public void COREEnterHighTempUnstableState()
    {
        COREUnstableState = true;
        TV.color = Color.yellow;
        tempFactor += 4;
    }
    [ClientRpc]
    public void COREExitHighTempUnstableState()
    {
        COREUnstableState = false;
        TV.color = Color.green;
        tempFactor += -4;
    }
    
    [ClientRpc]
    public void COREEnterLowTempUnstableState()
    {
        COREUnstableState = true;
        TV.color = Color.yellow;
        tempFactor = -5;
    }
    [ClientRpc]
    public void COREExitLowTempUnstableState()
    {
        COREUnstableState = false;
        TV.color = Color.green;
        tempFactor = 1;
    }

    [ClientRpc]
    public void COREEnterFreezeDown()
    {
        StartCoroutine(COREFreezeDownEnterCour());
    }
}
