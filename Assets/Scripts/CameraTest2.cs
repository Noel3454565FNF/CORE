using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraTest2 : NetworkBehaviour
{
    public Camera came;
    // Start is called before the first frame update
    void Start()
    {
        print("lol");
        if (isLocalPlayer)
        {
            came.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            came.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f);
        }
    }
}

