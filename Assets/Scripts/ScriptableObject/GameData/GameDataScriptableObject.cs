using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptableObject" , menuName = "ScriptableObject / GameData")]
public class GameDataScriptableObject : ScriptableObject
{
    public int playerBulletFireCount;
    public int playerEnemyKilledCount;
    public int playerScore;

    public void ResetData()
    {
        playerBulletFireCount = 0;
        playerEnemyKilledCount = 0;
        playerScore = 0;
    }
}
