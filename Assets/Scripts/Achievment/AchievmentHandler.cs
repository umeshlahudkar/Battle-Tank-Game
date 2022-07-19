using UnityEngine;

public class AchievmentHandler : GenericMonoSingleton<AchievmentHandler>
{
    [SerializeField] AchievmentHolderSO achievmentHolder;

    public void CheckForBulletAchievmentUnlock(int bulletCount)
    {
        for(int i = 0; i < achievmentHolder.bulletAchievmentSO.BulletFireAchievment.Length; i++)
        {
            if(achievmentHolder.bulletAchievmentSO.BulletFireAchievment[i].requirement == bulletCount)
            {
                UnlockAchievment(achievmentHolder.bulletAchievmentSO.BulletFireAchievment[i].Name);
            }
        }
    }

    public void CheckForEnemyKillAchievmentUnlock(int enemyKillCount)
    {
        for (int i = 0; i < achievmentHolder.enemyKilledAchievmentSO.EnemyKillAchievment.Length; i++)
        {
            if (achievmentHolder.enemyKilledAchievmentSO.EnemyKillAchievment[i].requirement == enemyKillCount)
            {
                UnlockAchievment(achievmentHolder.enemyKilledAchievmentSO.EnemyKillAchievment[i].Name);
            }
        }
    }

    private void UnlockAchievment(string name)
    {
        UIDisplay.Instance.DisplayAchievment(name);
    }
}
