
using UnityEngine;

public class TankService : GenericMonoSingleton<TankService>
{
    [SerializeField] TankListScriptableObject TankList;
    private TankScriptableObject tankScriptableObject;

    void Start()
    {
        Debug.Log("Tank Service");
        CreateTank();
    }

    public void CreateTank()
    {
        tankScriptableObject = TankList.tanks[GetRandomNumber()];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tankController = new TankController(tankModel, tankScriptableObject.tankView);
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, TankList.tanks.Length);
    }
   
}
