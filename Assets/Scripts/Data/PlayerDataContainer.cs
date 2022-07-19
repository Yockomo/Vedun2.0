using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField] private BasicPlayerStats basicPlayerStats;
    private SavingSystem savingSystem;
    private PlayerData playerData;

    private void Awake()
    {
        savingSystem = new SavingSystem();
        playerData = new PlayerData();
        bool hasSavedData;
        savingSystem.LoadPlayerData(out hasSavedData, ref playerData);
        if (!hasSavedData)
        {
            playerData = new PlayerData  {

            };
        }
    }
}
