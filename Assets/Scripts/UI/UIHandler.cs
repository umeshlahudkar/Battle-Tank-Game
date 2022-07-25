using UnityEngine;
using UnityEngine.SceneManagement;

// Handle UI in the Game Scene
public class UIHandler : MonoBehaviour
{
    // Invoke OnGamePauseEvent on Pause button click 
    public void OnPauseButtonClick()
    {
        EventService.Instance.InvokeOnGamePauseEvent();
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
        AudioManager.Instance.MuteAudio();
    }

    // Invoke OnGameResumeEvent on Pause button click 
    public void OnResumeButtonClick()
    {
        EventService.Instance.InvokeOnGameResumedEvent();
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
        AudioManager.Instance.UnMuteAudio();
    }

    // Load Lobby scene On Menu button click 
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
        AudioManager.Instance.UnMuteAudio();
    }

    // Reload Active scene on Replay button click 
    public void OnReplayButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClik);
    }
}
