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

using System.IO;
using UnityEngine;

public static class ConversationLogger
{
    static string path = Application.persistentDataPath + "/chatlog.txt";

    public static void Log(string speaker, string msg)
    {
        File.AppendAllText(path, $"[{System.DateTime.Now:HH:mm}] {speaker}: {msg}\n");
    }
}
