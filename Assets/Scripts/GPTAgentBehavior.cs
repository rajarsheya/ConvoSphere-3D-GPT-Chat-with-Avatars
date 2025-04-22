using UnityEngine;

public class GPTAgentBehavior : MonoBehaviour
{
    [Tooltip("Drag your GPTChat GameObject here")]
    public GPTChat gptChat;

    [Tooltip("How close you must be to interact")]
    public float interactDistance = 3f;

    [Tooltip("Key to press when in range")]
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        // Find the player by tag
        var player = GameObject.FindWithTag("Player");
        if (player == null) return;

        // Check distance
        if (Vector3.Distance(transform.position, player.transform.position) < interactDistance)
        {
            if (Input.GetKeyDown(interactKey))
            {
                // Optionally prefill a prompt
                gptChat.userInputField.text = "Hello, GPT bot!";
                gptChat.OnSendClicked();
            }
        }
    }
}
