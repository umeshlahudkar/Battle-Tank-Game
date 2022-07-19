using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class UIDisplay : GenericMonoSingleton<UIDisplay>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyKilledText;

    [Header("Achievment Display")]
    [SerializeField] GameObject achievmentDisplay;
    [SerializeField] TextMeshProUGUI achievmentDisplayText;

    [Header("Spwan Display")]
    [SerializeField] GameObject spwanDisplay;
    [SerializeField] TextMeshProUGUI timerDisplayText;

    private void Start()
    {
        EventService.Instance.OnEnemyKilled += DisplayScore;
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyKilled -= DisplayScore;
    }

    public void DisplayScore()
    {
        scoreText.text = "SCORE : " + ScoreController.score;

    }

    public void DisplayEnemyKill(int enemyKilled)
    {
        enemyKilledText.text = "Kill : " + enemyKilled.ToString();
    }

    public async void DisplayAchievment(string achievment)
    {
        achievmentDisplay.SetActive(true);
        achievmentDisplayText.text = achievment;

        await Task.Delay(System.TimeSpan.FromSeconds(3));

        achievmentDisplay.SetActive(false);
    }

    public async void DisplaySpwaning()
    {
        float time = 3;
        spwanDisplay.SetActive(true);
        timerDisplayText.text = time.ToString();

        await Task.Delay(System.TimeSpan.FromSeconds(1));
        time--;
        timerDisplayText.text = time.ToString();

        await Task.Delay(System.TimeSpan.FromSeconds(1));
        time--;
        timerDisplayText.text = time.ToString();

        await Task.Delay(System.TimeSpan.FromSeconds(1));

        spwanDisplay.SetActive(false);
    }
}
