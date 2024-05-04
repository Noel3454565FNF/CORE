using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwavefreeze : MonoBehaviour
{
    private Animation Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animation>();
        Anim.Play();
    }

    IEnumerator ou()
    {
        yield return new WaitForSeconds(0.55f);
        GameObject.Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
