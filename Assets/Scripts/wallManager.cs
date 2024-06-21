using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallManager : MonoBehaviour
{
    private GameObject CORER;
    public GameObject CORE;
    public COREManager COREM;
    public Rigidbody2D rgb;
    public bool Attracted = false;
    public float gravityFactor = 10000;
    public bool setup = false;
    public bool mode = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "shockwaveFreeze2(Clone)")
        {
            mode = true;
        }
        CORE = GameObject.Find("CORE");
        CORER = GameObject.Find("CORE room");
        COREM = (COREManager)CORER.GetComponent(typeof(COREManager));
        rgb = (Rigidbody2D)gameObject.GetComponent(typeof(Rigidbody2D));
        setup = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BO()
    {
        Attracted = true;

    }

    private void FixedUpdate()
    {
        if (Attracted)
        {
            rgb.AddForce((CORE.transform.position - transform.position).normalized * rgb.mass * gravityFactor / (CORE.transform.position - transform.position).sqrMagnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (setup == true)
        {
            if (collision.gameObject.name == "CORE" && COREM.COREBlackHole == true && gameObject.name != "shockwaveFreeze1(Clone)" && gameObject.tag != "PLAYER" && gameObject.name != "shockwaveFreeze2(Clone)" && mode == false)
            {
                print(gameObject.name);
                GameObject.Destroy(gameObject);
            }
            if (collision.gameObject.name == "CORE" && COREM.COREBlackHole == true && gameObject.name != "shockwaveFreeze1(Clone)" && gameObject.name != "shockwaveFreeze2(Clone)" && mode == false && gameObject.tag == "PLAYER")
            {
                print(gameObject.tag + " is a player and will be teleported in the blackhole when i code it");
            }
        }
    }
}
