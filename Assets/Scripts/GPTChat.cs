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

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GPTChat : MonoBehaviour
{
    [Header("OpenAI Settings")]
    public string apiKey = "Enter your OpenAI API Key here";

    [Header("UI Elements")]
    public TMP_InputField userInputField;
    public TMP_Text gptResponseText;

    [Header("Avatar Animation")]
    public Animator avatarAnimator;  // Drag your avatar's Animator here

    private bool isWaiting = false;

    public void OnSendClicked()
    {
        if (!isWaiting && !string.IsNullOrWhiteSpace(userInputField.text))
        {
            StartCoroutine(SendChat(userInputField.text, retryCount: 1));
        }
    }

    IEnumerator SendChat(string input, int retryCount)
    {
        isWaiting = true;

        yield return new WaitForSeconds(5f); // cooldown to avoid spamming

        // Prepare the JSON body
        string jsonBody = "{\"model\": \"gpt-3.5-turbo-0125\", \"messages\": [{\"role\": \"user\", \"content\": \"" + input + "\"}], \"max_tokens\": 30}";

        // Log the request for debugging
        Debug.Log("Sending JSON: " + jsonBody);

        // Set up the UnityWebRequest
        UnityWebRequest request = new UnityWebRequest("https://api.openai.com/v1/chat/completions", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // Send the request and wait for the response
        yield return request.SendWebRequest();

        // Debug the full URL and response
        Debug.Log("Request URL: " + request.url);
        Debug.Log("Response: " + request.downloadHandler.text);

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Extract the response from JSON
            string json = request.downloadHandler.text;
            string content = ExtractContentFromResponse(json);

            // Log the conversation to the file
            ConversationLogger.Log("User", input);  // Log user message
            ConversationLogger.Log("GPT", content); // Log GPT response

            gptResponseText.text = content;

            // Trigger the "Talking" animation
            if (avatarAnimator != null)
            {
                avatarAnimator.SetTrigger("Talking");
            }
        }
        else if (request.responseCode == 429 && retryCount > 0)
        {
            // Handle rate limiting: retry once after a delay
            gptResponseText.text = "⚠️ Rate limit reached. Retrying in 5s...";
            yield return new WaitForSeconds(5f);
            StartCoroutine(SendChat(input, retryCount - 1)); // retry once
        }
        else
        {
            // Display the error message from the server
            gptResponseText.text = "Error: " + request.error + " (Code: " + request.responseCode + ")";
        }

        isWaiting = false;
    }

    // Function to extract the content field from the response JSON
    string ExtractContentFromResponse(string json)
    {
        int index = json.IndexOf("\"content\":\"") + 10;
        int end = json.IndexOf("\"", index);
        if (index < 10 || end < index) return "⚠️ Could not parse response.";

        string content = json.Substring(index, end - index);
        return content.Replace("\\n", "\n").Replace("\\\"", "\"");
    }
}
