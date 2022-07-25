using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : GenericMonoSingleton<UIDisplay>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyKilledText;

    [SerializeField] GameObject achievmentDisplay;
    [SerializeField] TextMeshProUGUI achievmentDisplayText;


    public void DisplayScore(int score)
    {
        scoreText.text = "SCORE : " + score;

    }

    public void DisplayEnemyKillText(int enemyKilled)
    {
        enemyKilledText.text = "Kill : " + enemyKilled.ToString();
    }

    public async void DisplayAchievmentText(string achievment)
    {
        achievmentDisplay.SetActive(true);
        achievmentDisplayText.text = achievment;

        await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(3));

        achievmentDisplay.SetActive(false);
    }
}
