using UnityEngine;

public class AchievmentHandler : MonoBehaviour
{
    [SerializeField] AchievmentHolderSO achievmentHolder;
    [SerializeField] GameDataScriptableObject gameData;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        EventService.Instance.OnBulletFire += CheckForBulletAchievmentUnlock;
        EventService.Instance.OnEnemyKilled += CheckForEnemyKillAchievmentUnlock;
    }

    private void OnDisable()
    {
        EventService.Instance.OnBulletFire -= CheckForBulletAchievmentUnlock;
        EventService.Instance.OnEnemyKilled -= CheckForEnemyKillAchievmentUnlock;
    }

    // Check for Bullet Achievment Locked or Unlocked
    public void CheckForBulletAchievmentUnlock()
    {
        BulletAchievmentSO bulletAchievmentSO = achievmentHolder.bulletAchievmentSO;
        for (int i = 0; i < achievmentHolder.bulletAchievmentSO.BulletFireAchievment.Length; i++)
        {
            if (bulletAchievmentSO.BulletFireAchievment[i].requirement == gameData.playerBulletFireCount &&
                    GetAchievmentStatus(bulletAchievmentSO.BulletFireAchievment[i].Name) == AchievmentStatus.Locked)
            {
                UnlockAchievmentStatus(bulletAchievmentSO.BulletFireAchievment[i].Name);
            }
        }
    }

    // Check for Enemy Killed Achievment Locked or Unlocked
    public void CheckForEnemyKillAchievmentUnlock()
    {
        EnemyKilledAchievmentSO enemyKilledAchievmentSO = achievmentHolder.enemyKilledAchievmentSO;
        for (int i = 0; i < achievmentHolder.enemyKilledAchievmentSO.EnemyKillAchievment.Length; i++)
        {
            if (enemyKilledAchievmentSO.EnemyKillAchievment[i].requirement == gameData.playerEnemyKilledCount &&
                GetAchievmentStatus(enemyKilledAchievmentSO.EnemyKillAchievment[i].Name) == AchievmentStatus.Locked)
            {
                UnlockAchievmentStatus(enemyKilledAchievmentSO.EnemyKillAchievment[i].Name);
            }
        }
    }

    public AchievmentStatus GetAchievmentStatus(string name)
    {
        AchievmentStatus status =(AchievmentStatus)PlayerPrefs.GetInt(name);
        return status;
    }

    public void UnlockAchievmentStatus(string name)
    {
        PlayerPrefs.SetInt(name, (int)AchievmentStatus.Unlocked);
        UIDisplay.Instance.DisplayAchievment(name);
        EventService.Instance.InvokeOnAchievmentUnlockedEvent();
    }
}

public enum AchievmentStatus
{
    Locked,
    Unlocked
}

