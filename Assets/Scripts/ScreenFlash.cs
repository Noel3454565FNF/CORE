using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ScreenFlash : NetworkBehaviour 
{

    public Animation whiteflash;

    public AnimationClip wfStartup; //

    public GameObject flash;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);

    }

    public void startupflash()
    {
        flash.SetActive(true);

        whiteflash.clip = wfStartup;
        whiteflash.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
