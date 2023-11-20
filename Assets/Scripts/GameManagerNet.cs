using System.Collections.Generic;
using UnityEngine;
using Mirror;


//Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
//API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html


public class GameManagerNet : NetworkBehaviour
{
    public float COREStartFailureChance;

    void Start()
    {
        
        COREStartFailureChance = Random.value;

    }

}
