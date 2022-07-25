using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the lobby scene UI
public class LobbySceneUIController : MonoBehaviour
{
    
    public void OnPlayButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
    }
}
