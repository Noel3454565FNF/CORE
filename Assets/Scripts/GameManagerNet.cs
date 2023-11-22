using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Rendering.Universal;


//Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
//API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html


/*public struct CORE
{
    public string COREStatut;
    public int COREtemp;
    public bool COREFailedStart;
    public SpriteRenderer COREColor;
    public Light2D CORELight;
    public SpriteRenderer TV;


}
*/
public class GameManagerNet : NetworkBehaviour
{
    public COREManager COREManager;
    public GameManager GameManager;
    public COREPanel COREPanel;

    /*    public SyncList<CORE> COREThings = new SyncList<CORE>();
    */
    [SyncVar]
    public bool COREStartFailureChance;

    void Start()
    {
        
    }
    private void OnConnectedToServer()
    {
        COREStartFailureChance = Random.value >= 0.6f;
    }

}
