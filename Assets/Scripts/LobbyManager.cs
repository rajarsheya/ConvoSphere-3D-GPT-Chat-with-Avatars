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
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [Header("UI References")]
    public TMP_InputField roomNameInput;
    public TMP_Text statusText;
    public TMP_Text playerNameText;

    void Start()
    {
        string username = PlayerPrefs.GetString("USERNAME", "Guest");
        PhotonNetwork.NickName = username;
        playerNameText.text = $"Welcome, {username}";

        statusText.text = "Connecting to Photon...";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnJoinRoomClicked()
    {
        string roomName = roomNameInput.text.Trim();

        if (string.IsNullOrEmpty(roomName))
        {
            statusText.text = "Room name cannot be empty.";
            return;
        }

        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        statusText.text = $"Joining room: {roomName}...";
    }

    public override void OnConnectedToMaster()
    {
        statusText.text = "Connected to Photon!";
    }

    public override void OnJoinedRoom()
    {
        statusText.text = $"Joined Room: {PhotonNetwork.CurrentRoom.Name}";
        // Use PhotonNetwork.LoadLevel for synchronized scene loading across all players
        PhotonNetwork.LoadLevel("Game");  // Make sure the multiplayer scene is named "Game"
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        statusText.text = $"Failed to join room: {message}";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        statusText.text = $"Disconnected from Photon: {cause}";
    }
}
