using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;
using UnityEngine.UI;


public class COREManager : MonoBehaviour
{

    public GameManager GM;
    public GameManagerNet GMN;
    public SpriteRenderer COREColor;
    public string COREStatut;
    public int COREtemp;


    public Color redStat;
    public Color yellowStat;
    public Color greenStat;
    public Color offStat;
    public ColorBlock initStat;
    public Light2D CORELight;
    public SpriteRenderer TV;

    public bool COREFailedStart;

    // Start is called before the first frame update
    void Start()
    {
        print(NetworkServer.activeHost);
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


    public void COREInit()
    {
        StartCoroutine(COREInite());
        print("core Init");
    }

    IEnumerator COREInite()
    {
        yield return new WaitForSeconds(1f);
        GM.COREROOMLights(0.23f);
        CORELight.intensity = 1f;
        print("core startup 1");
        yield return new WaitForSeconds(3f);
        if (GMN.COREStartFailureChance >= 0.6f)
        {
            print("core failed startup");
            COREFailedStart = true;
            COREColor.color = redStat;
            TV.color = redStat;
            COREColor.color = Color.yellow;
            TV.color = Color.yellow;
        }
        else
        {
            print("core success startup");
            COREFailedStart = false;
            COREColor.color = Color.green;
            TV.color =  Color.green;
        }
        StopCoroutine(COREInite());

    }
}
