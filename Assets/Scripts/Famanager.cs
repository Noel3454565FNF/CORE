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

    public GameObject FABG;


    // Start is called before the first frame update
    void Start()
    {
        FABG.SetActive(false);   
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
            FABG.SetActive(true);
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
        FABG.SetActive(false);
    }


    [ClientRpc]
    public void FAMangerClient(string text)
    {
        FABG.SetActive(true);
        Fabg.color = new Color(255, 255, 255, 79);
        Fatxt.text = text;
        StartCoroutine(FAServerVanish());
    }

}
