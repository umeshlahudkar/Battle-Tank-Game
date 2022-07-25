using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : GenericMonoSingleton<EventService>
{
    public event Action OnEnemyKilled;

    public event Action OnPlayerKilled;

    public event Action OnBulletFire;
    //public event Action OnEnemyKilled;

    public void InvokeOnBulletFireEvent()
    {
        OnBulletFire?.Invoke();
    }

    public void InvokeOnEnemyKillEvent( )
    {
        OnEnemyKilled?.Invoke();
    }
}

