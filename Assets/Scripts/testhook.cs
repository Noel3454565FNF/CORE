using UnityEngine;

public class testhook : MonoBehaviour
{
    private DiscordWebhook discordWebhook;

    void Start()
    {
        discordWebhook = FindObjectOfType<DiscordWebhook>();

        if (discordWebhook != null)
        {
            discordWebhook.SendMessageToDiscord("Hello, Discord! This is a message from Unity.");
        }
    }
}
