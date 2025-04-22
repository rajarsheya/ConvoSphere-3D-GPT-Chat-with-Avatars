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
