using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int score;
    int onEnemyKilled = 15;
    int onAchievmentUnlocked = 100;

    [SerializeField] GameDataScriptableObject gameData;

    private void Start()
    {
        EventService.Instance.OnAchievmentUnlocked += UpdateScoreOnAchievmentUnlocked;
        EventService.Instance.OnEnemyKilled += UpdateScoreOnEnemyKilled;
    }

    private void OnDisable()
    {
        EventService.Instance.OnAchievmentUnlocked -= UpdateScoreOnAchievmentUnlocked;
        EventService.Instance.OnEnemyKilled -= UpdateScoreOnEnemyKilled;
    }

    public void UpdateScoreOnEnemyKilled()
    {
        score += onEnemyKilled;
        gameData.playerScore = score;
        UpdateHighScore();
    }

    public void UpdateScoreOnAchievmentUnlocked()
    {
        score += onAchievmentUnlocked;
        gameData.playerScore = score;
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}

