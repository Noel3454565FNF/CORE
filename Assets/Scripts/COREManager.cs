using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;
using UnityEngine.UI;

public class COREManager : NetworkBehaviour
{

    public GameManager GM;
    public GameManagerNet GMN;
    public COREPanel COREP;
    public SpriteRenderer COREColor;

    public Light2D CORELight;
    public SpriteRenderer TV;
    public GameObject CORE;

    public GameObject PL1;
    public GameObject PL2;
    public GameObject CL1;

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

    public int COREtemp;
    public NetworkWriter lol;




    // Start is called before the first frame update
    void Start()
    {
        TV.color = offStat;
        COREColor.color = offStat;
        COREStatut = "off";
        COREtemp = 100;
        CORELight.color = offStat;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ClientRpc]
    public void COREInit()
    {
        StartCoroutine(COREInite());
        print("core Init");
    }

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




    }
}
