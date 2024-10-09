using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip[] FASSpeech;

    public AudioClip[] FreezedownSpeech;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AudioPlayer(string whattoplay)
    {
        if (whattoplay == null)
        {
            print("NULL RECEIVED!");
        }
        else if (whattoplay == "EnterFreezedown")
        {
            audioSource.clip = FreezedownSpeech[0];
            audioSource.Play();
        }
    }
}
