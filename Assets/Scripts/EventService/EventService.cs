using System;

public class EventService : GenericMonoSingleton<EventService>
{
    public event Action OnEnemyKilled;
    public event Action OnPlayerKilled;
    public event Action OnBulletFire;

    public void InvokeOnBulletFireEvent()
    {
        OnBulletFire?.Invoke();
    }

    public void InvokeOnEnemyKillEvent( )
    {
        OnEnemyKilled?.Invoke();
    }
}

