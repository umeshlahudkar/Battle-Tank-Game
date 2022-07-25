using UnityEngine;

public class TankService : GenericMonoSingleton<TankService>
{
    [SerializeField] TankListScriptableObject TankList;
    [SerializeField] GameDataScriptableObject gameData;
    public TankView activePlayer;
    public bool isGameOver = false;

    void Start()
    {
        CreateTank();
    }

    // Randomly create new tank
    public void CreateTank()
    {
        TankScriptableObject tankScriptableObject = TankList.tanks[GetRandomNumber()];
        TankModel tankModel = new TankModel(tankScriptableObject, gameData);
        TankController tankController = new TankController(tankModel, tankScriptableObject.tankView);
        tankController.Enable();
    }

    // Generate Random number
    private int GetRandomNumber()
    {
        return Random.Range(0, TankList.tanks.Length);
    }
   
}

public enum TankType
{
    None,
    Red,
    Blue,
    Green
}
