using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;


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


    IEnumerator COREInit()
    {
        yield return new WaitForSeconds(1f);
        GM.COREROOMLights(0.23f);
        CORELight.intensity = 1f;
        yield return new WaitForSeconds(3f);
        if (GMN.COREStartFailureChance >= 0.6f)
        {
            COREFailedStart = true;
            COREColor.color = redStat;
            TV.color = redStat;
        }
        else
        {
            COREFailedStart = false;
            COREColor.color = greenStat;
            TV.color = greenStat;
        }
        StopCoroutine(COREInit());

    }
}
