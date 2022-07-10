using UnityEngine;

public class TankService : GenericMonoSingleton<TankService>
{
    [SerializeField] TankListScriptableObject TankList;
    public TankView activePlayer;
    public bool isGameOver = false;

    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        TankScriptableObject tankScriptableObject = TankList.tanks[GetRandomNumber()];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tankController = new TankController(tankModel, tankScriptableObject.tankView);
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, TankList.tanks.Length);
    }
   
}
