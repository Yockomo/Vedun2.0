using UnityEngine;
using System.IO;
using UnityEditor;

public class SavingSystem
{
#if(UNITY_EDITOR)
    [MenuItem("Utils/Clear progress")]
#endif
    public static void ClearProgress()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerSaveData.txt"))
        {
            File.Delete(Application.persistentDataPath + "/PlayerSaveData.txt");
        }
        if (File.Exists(Application.persistentDataPath + "/WorldSaveData.txt"))
        {
            File.Delete(Application.persistentDataPath + "/WorldSaveData.txt");
        }
#if(UNITY_EDITOR)
        Debug.Log("DataCleared!");
#endif
    }

    public void SavePlayerData(CharacterController controller)
    {

        PlayerData playerData = new PlayerData();
        //PlayerData playerData = new PlayerData
        //{
        //    HealthData = playerHealth,
        //    EnergyData = playerEnergy,
        //    HealthPacksData = healthPacks,
        //    EnergyPacksData = energyPacks,
        //    ScrollsCountData = scrollsCount,
        //};
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/PlayerSaveData.txt", json);
    }

    public void LoadPlayerData(out bool hasSavedData, ref PlayerData playerData)
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerSaveData.txt"))
        {
            hasSavedData = true;
            string savedString = File.ReadAllText(Application.persistentDataPath + "/PlayerSaveData.txt");
            playerData = JsonUtility.FromJson<PlayerData>(savedString);
#if (UNITY_EDITOR)
            Debug.Log("PlayerDataLoaded!");
#endif
            
        }
        else
        {
            hasSavedData = false;
#if (UNITY_EDITOR)
            Debug.Log("NoSavedPlayerData!");
#endif
        }
    }
}
public class PlayerData
{
    public int LevelData;
    public int StrengthData;
    public int AgilityData;
    public int HealthData;
    public int EnergyData;
    public float SpeedData;
    public int DefenceData;
    public int LuckData;
    public int HealthPacksData;
    public int EnergyPacksData;
    public int ScrollsCountData;
}