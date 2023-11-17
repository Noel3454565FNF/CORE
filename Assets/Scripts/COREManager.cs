using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;

public class COREManager : MonoBehaviour
{

    public SpriteRenderer COREColor;
    public string COREStatut;
    public int COREtemp;


    public Color redStat;
    public Color yellowStat;
    public Color greenStat;
    public Color offStat;
    public Light2D CORELight;
    public SpriteRenderer TV;

    

    // Start is called before the first frame update
    void Start()
    {
        print(NetworkServer.activeHost);
        TV.color = offStat;
        COREColor.color = offStat;
        COREStatut = "off";
        COREtemp = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
