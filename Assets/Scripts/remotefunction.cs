using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Mirror;

public class remotefunction : NetworkBehaviour
{
    private string oldUUID = "null";
    public GameManager GM;
    public Famanager FA;

    [System.Serializable]
    public class data
    {
        public string eventname;
        public string stringarg;
        public string eventID;
    }

    private string url = "http://localhost:3000/custom-event";

    // Start is called before the first frame update
    void Start()
    {
        // Start the repeating function call
        if (isServer)
        {
            InvokeRepeating("StartFetchingJsonData", 0f, 60f); // Calls the method every 60 seconds
        }
    }

    void StartFetchingJsonData()
    {
        // Start the coroutine to fetch the JSON data
        if (isServer)
        {
            StartCoroutine(FetchJsonData());
        }
    }

    IEnumerator FetchJsonData()
    {
        // Send a GET request to the URL
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + request.error );
        }
        else
        {
            // Parse the JSON data
            data remotefuncData = JsonUtility.FromJson<data>(request.downloadHandler.text);

            // Output the parsed data
            if (remotefuncData.eventID == oldUUID)
            {
                Debug.Log("EVENT ALREADY REGISTERED!");
            }
            else
            {
                if (remotefuncData.eventname != null | remotefuncData.eventID != null)
                {
                    Debug.Log("Event Name: " + remotefuncData.eventname);
                    Debug.Log("String Arg: " + remotefuncData.stringarg);
                    Debug.Log("UUID: " + remotefuncData.eventID);
                    oldUUID = remotefuncData.eventID;
                    if (isServer)
                    {
                        RemoteFunctionCalled(remotefuncData.eventname, remotefuncData.stringarg, remotefuncData.eventID);
                    }

                }
                else
                {
                    
                }
            }
        }
    }


    public void RemoteFunctionCalled(string name, string sa, string uuid)
    {
        if (name == "FA")
        {
            FA.FAMangerFunc(sa);
        }
        else if (name == "WARHEAD")
        {
            //Warhead event;
        }
        else if (name == "FORCEDWARHEAD")
        {
            //Warhead event but shutdown will fail;
        }
        else if (name == "MELTDOWN")
        {
            //CORE Meltdown;
        }
        else if (name == "BIOHAZARDPROTOCOL")
        {
            //BIOHAZARD CONTAINMENT AND SD; 
        }

    }
}
