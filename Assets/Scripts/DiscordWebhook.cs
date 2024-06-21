using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DiscordWebhook : MonoBehaviour
{
    // Replace this with your webhook URL
    private string webhookUrl = "https://discord.com/api/webhooks/1187378869402075168/LP0sT-l-geAnpMcBeZtjFU1MUk4yPw_tKN-IKhNBJPmwSdFHO_Kot-fcz10GNNzi-RBb";

    // Method to send a message
    public void SendMessageToDiscord(string message)
    {
        StartCoroutine(PostToDiscord(message));
    }

    private IEnumerator PostToDiscord(string message)
    {
        // Create the JSON payload
        var payload = new
        {
            content = message,
            username = "UnityBot"
        };

        // Convert the payload to JSON format
        string jsonPayload = JsonUtility.ToJson(payload);

        // Create a UnityWebRequest
        using (UnityWebRequest webRequest = new UnityWebRequest(webhookUrl, "POST"))
        {
            // Set the content type and payload
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonPayload);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error sending message to Discord: " + webRequest.error);
            }
            else
            {
                Debug.Log("Message sent to Discord successfully!");
            }
        }
    }
}
