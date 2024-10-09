using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public AudioSource AS;
    public AudioClip AC;
    public AudioClip ITBHSpeech;

    public AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AS.clip = AC;
        AS.Play();
        AS.loop = true;
    }


    IEnumerator Speech()
    {
        yield return new WaitForSeconds(AC.length);
        AS.Stop();
        AS.loop = false;
        AS.clip = ITBHSpeech;
        AS.Play();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
