using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int score;
    int enemtKilledMultiplier = 10;
    int bulletHitMultiplier = 2;

    private void Start()
    {
        EventService.Instance.OnEnemyKilled += UpdateScoreByEnemyKilled;
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyKilled -= UpdateScoreByEnemyKilled;
    }

    public void UpdateScoreByBulletHit()
    {
        score += bulletHitMultiplier; 
    }

    public void UpdateScoreByEnemyKilled()
    {
        score += enemtKilledMultiplier;
    }
}
