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
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void OnLoginClicked()
    {
        string username = usernameInput.text.Trim();
        if (!string.IsNullOrEmpty(username))
        {
            PlayerPrefs.SetString("USERNAME", username);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Lobby");  // make sure the scene is named exactly "Lobby"
        }
        else
        {
            Debug.LogWarning("Username is empty!");
        }
    }
}
