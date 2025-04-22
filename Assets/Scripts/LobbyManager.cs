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
