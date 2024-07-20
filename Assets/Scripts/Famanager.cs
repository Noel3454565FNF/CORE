using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Famanager : NetworkBehaviour
{
    public Camera cam;
    public Image Fabg;
    public Text Fatxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FAMangerFunc(string text)
    {
        if (isServer)
        {
            FAMangerClient(text);
            Fabg.color = new Color(255, 255, 255, 79);
            Fatxt.text = text;
            StartCoroutine(FAServerVanish());
        }
        else
        {
            print("wait you turn client :>");
        }
    }


    IEnumerator FAServerVanish()
    {
        yield return new WaitForSeconds(10f);
        Fabg.color = new Color(255, 255, 255, 0);
        Fatxt.text = "";
    }


    [ClientRpc]
    public void FAMangerClient(string text)
    {
        Fabg.color = new Color(255, 255, 255, 79);
        Fatxt.text = text;
        StartCoroutine(FAServerVanish());
    }

}
