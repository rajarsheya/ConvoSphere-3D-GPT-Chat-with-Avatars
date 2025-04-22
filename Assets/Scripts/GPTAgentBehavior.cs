// --------------------------------------------------------------------------------------------------------------------------------------------------
// Project : ConvoSphere - 3D GPT Chat with Avatars
//
// ConvoSphere is a Unity-based 3D multiplayer chat application where users interact using customizable avatars powered by GPT-3.5.
// It uses Photon PUN for networking and integrates AI-driven conversations for immersive social experiences.
//
// Author: Arsheya Raj
// Date: 22nd April 2025
// --------------------------------------------------------------------------------------------------------------------------------------------------
//
//     Implemented a real-time multiplayer environment in Unity with GPT-powered NPC avatars using Photon PUN.
//     Enabled AI-driven text chat responses with simple emotive avatar animations to enhance interactions.
//
// --------------------------------------------------------------------------------------------------------------------------------------------------

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
