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
using Photon.Pun;
using TMPro;

public class NetworkPlayer : MonoBehaviourPun
{
    [Header("UI")]
    public TMP_Text nameTag;   // drag in your in‑scene text label for this player

    void Start()
    {
        // Set display name
        string displayName = photonView.IsMine
            ? PhotonNetwork.NickName
            : photonView.Owner.NickName;
        if (nameTag != null)
            nameTag.text = displayName;

        // Disable camera (or other local‑only scripts) on remote players
        if (!photonView.IsMine)
        {
            var cam = GetComponentInChildren<Camera>();
            if (cam) cam.gameObject.SetActive(false);
        }
    }
}
