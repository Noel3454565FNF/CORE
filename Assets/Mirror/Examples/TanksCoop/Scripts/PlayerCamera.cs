using UnityEngine;
using UnityEngine.SceneManagement;

// This sets up the scene camera for the local player

namespace Mirror.Examples.TanksCoop
{
    public class PlayerCamera : NetworkBehaviour
    {
        Camera mainCam;

        public override void OnStartClient()
        {
            if (isLocalPlayer)
            {
                return;
            }
            else
            {
                // Disable camera, input scripts, colliders etc. here
                GetComponent<Camera>().enabled = false;
            }
        }
        public override void OnStopLocalPlayer()
        {
            if (mainCam != null)
            {
                mainCam.transform.SetParent(null);
                SceneManager.MoveGameObjectToScene(mainCam.gameObject, SceneManager.GetActiveScene());
                mainCam.orthographic = true;
                mainCam.orthographicSize = 15f;
                mainCam.transform.localPosition = new Vector3(0f, 70f, 0f);
                mainCam.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            }
        }
    }
}
