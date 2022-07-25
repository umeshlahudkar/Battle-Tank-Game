using System;

public class EventService : GenericMonoSingleton<EventService>
{
    public event Action OnBulletFire;
    public event Action OnAchievmentUnlocked;
    public event Action OnEnemyKilled;

    public event Action OnGamePause;
    public event Action OnGameResume;

    public event Action OnGameOver;

    public void InvokeOnBulletFireEvent()
    {
        OnBulletFire?.Invoke();
    }

    public void InvokeOnAchievmentUnlockedEvent()
    {
        OnAchievmentUnlocked?.Invoke();
    }

    public void InvokeOnEnemyKilledEvent()
    {
        OnEnemyKilled?.Invoke();
    }

    public void InvokeOnGamePauseEvent()
    {
        OnGamePause?.Invoke();
    }

    public void InvokeOnGameResumedEvent()
    {
        OnGameResume?.Invoke();
    }

    public void InvokeOnGameOverEvent()
    {
        OnGameOver?.Invoke();
    }
}

