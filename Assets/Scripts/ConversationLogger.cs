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
