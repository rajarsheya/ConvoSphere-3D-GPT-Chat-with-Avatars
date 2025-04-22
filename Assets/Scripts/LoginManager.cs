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
