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

    public Light2D CORELight;
    public SpriteRenderer TV;
    public TextMeshPro TVText;
    public GameObject CORE;

    public GameObject PL1;
    public GameObject PL2;
    public GameObject CL1;

    public Slider PL1Slide;
    public Slider PL2Slide;
    public Slider CL1Slide;


    [SyncVar]
    public string CL1Power;
    [SyncVar]
    public string PL1Power;
    [SyncVar]
    public string PL2Power;
    public Vector3[] PLPower;
    public Vector3[] CLPower;

    [SyncVar]
    public bool COREFailedStart;
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
        
    }

    // Update is called once per frame
    void Update()
    {

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
        GM.COREROOMLights(1f);
        TV.color = Color.green;
        COREStatut = "normal";
        COREP.StartupButton.gameObject.SetActive(false);
        COREP.StartupButtonText.gameObject.SetActive(false);
        //COREP.activePanel();
        CORETemp = 1500;
        TVText.text = CORETemp+"C�";
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
            int nextT = 1;
            if (COREStatut == "normal")
            {
                if (PL1Power == "offline")
                {
                    nextT = nextT + 0;
                }
                if (PL1Power == "minimum")
                {
                    nextT = nextT + 3;
                }
                if (PL1Power == "medium")
                {
                    nextT = nextT + 5;
                }
                if (PL1Power == "maximum")
                {
                    nextT = nextT + 7;
                }

                if (PL2Power == "offline")
                {
                    nextT = nextT + 0;
                }
                if (PL2Power == "minimum")
                {
                    nextT = nextT + 3;
                }
                if (PL2Power == "medium")
                {
                    nextT = nextT + 5;
                }
                if (PL2Power == "maximum")
                {
                    nextT = nextT + 7;
                }

                if(CL1Power == "offline")
                {
                    nextT = nextT - 0;
                }
                if (CL1Power == "actif")
                {
                    nextT = nextT - 10;
                }
                CORETemp += nextT;
                TVText.text = CORETemp + "C�";
                CORETempUpdateClient();
                print("nextT applied "+nextT+" and "+CORETemp+" core statut is "+COREStatut);
                nextT = 0;
                StartCoroutine(CORETempUpdate());

            }

        }

    }

    [ClientRpc]
    public void CORETempUpdateClient()
    {
        TVText.text = CORETemp + "C�";
    }



    public void PL1SliderValueChanged(float haha)
    {
        if (PL1Slide.value == 1)
        {
            PL1Power = "minimum";
        }
        if (PL1Slide.value == 2)
        {
            PL1Power = "medium";
        }
        if (PL1Slide.value == 3)
        {
            PL1Power = "maximum";
        }
        print(PL1Power);
    }

    public void PL2SliderValueChanged(float haha)
    {
        if (PL2Slide.value == 1)
        {
            PL2Power = "minimum";
        }
        if (PL2Slide.value == 2)
        {
            PL2Power = "medium";
        }
        if (PL2Slide.value == 3)
        {
            PL2Power = "maximum";
        }
        print(PL2Power);
    }

}
