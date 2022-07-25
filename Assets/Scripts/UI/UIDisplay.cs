using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class UIDisplay : GenericMonoSingleton<UIDisplay>
{
    [Header("Score&Enemy Display")]
    [SerializeField] GameObject scoreEnemyDisplay;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyKilledText;

    [Header("Achievment Display")]
    [SerializeField] GameObject achievmentDisplay;
    [SerializeField] TextMeshProUGUI achievmentDisplayText;

    [Header("Spwan Display")]
    [SerializeField] GameObject spwanDisplay;
    [SerializeField] TextMeshProUGUI timerDisplayText;

    [Header("Game Pause Panel")]
    [SerializeField] GameObject gamePauseScreen;

    [Header("Game Over Panel")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI gameOverKilledText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;

    [SerializeField] GameDataScriptableObject gameData;
    [SerializeField] Button pauseButton;

    private async  void Start()
    {
        // Wait for 2S To subscribe the event in Order, like First Update Score then Display Score
        await Task.Delay(System.TimeSpan.FromSeconds(2));
        EventService.Instance.OnGamePause += EnablePauseScreen;
        EventService.Instance.OnGameResume += DisablePauseScreen;
        EventService.Instance.OnGameOver += EnableGameOverScreen;
        EventService.Instance.OnEnemyKilled += DisplayScore;
        EventService.Instance.OnEnemyKilled += DisplayEnemyKill;
    }

    private void OnDisable()
    {
        EventService.Instance.OnGamePause -= EnablePauseScreen;
        EventService.Instance.OnGameResume -= DisablePauseScreen;
        EventService.Instance.OnGameOver -= EnableGameOverScreen;
        EventService.Instance.OnEnemyKilled += DisplayScore;
        EventService.Instance.OnEnemyKilled += DisplayEnemyKill;
    }

    public void DisplayScore()
    {
        scoreText.text = "SCORE : " + gameData.playerScore;
    }

    public void DisplayEnemyKill()
    {
        enemyKilledText.text = "Kill : " + gameData.playerEnemyKilledCount.ToString();
    }

    // Display Achievment Unlocked Text
    public async void DisplayAchievment(string achievment)
    {
        achievmentDisplay.SetActive(true);
        achievmentDisplayText.text = achievment;

        await Task.Delay(System.TimeSpan.FromSeconds(3));

        achievmentDisplay.SetActive(false);
    }

    public async void DisplayWaitTime()
    {
        int time = 3;
        spwanDisplay.SetActive(true);
        await DisplayText(time);
        time--;
        await DisplayText(time);
        time--;
        await DisplayText(time); 

        spwanDisplay.SetActive(false);
    }

    async Task DisplayText(int time)
    {
        timerDisplayText.text = time.ToString();
        await Task.Delay(System.TimeSpan.FromSeconds(1));
    }

    public void EnablePauseScreen()
    {
        gamePauseScreen.SetActive(true);
    }

    public void DisablePauseScreen()
    {
        gamePauseScreen.SetActive(false);
    }

    public async void EnableGameOverScreen()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(2));
        scoreEnemyDisplay.SetActive(false);
        pauseButton.interactable = false;
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "SCORE : " + gameData.playerScore;
        gameOverKilledText.text = "KILL : " + gameData.playerEnemyKilledCount;
        gameOverHighScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore",0);
    }

    public void DisableGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }
}
