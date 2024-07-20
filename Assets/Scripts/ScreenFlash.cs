using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ScreenFlash : NetworkBehaviour 
{

    public Animation whiteflash;

    public AnimationClip wfStartup; //

    // Start is called before the first frame update
    void Start()
    {


    }

    public void startupflash()
    {
        
        whiteflash.clip = wfStartup;
        whiteflash.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
