using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class StartOperations : Singleton<StartOperations>
{
    public GameDatas gameDatas;

    // Start is called before the first frame update
    void Awake()
    {
        //if (!PlayerPrefs.HasKey("DownloadDate"))
        //{
        //    PlayerPrefs.SetString("DownloadDate", DateTime.Now.ToString("yyyyMMdd"));
        //}

        LoadData();

    }

    // private void Update()
    // {
    //     gameData.sessionSeconds += Time.deltaTime;
    //     gameData.totalSeconds += Time.deltaTime;
    // }


    void LoadData()
    {
#if UNITY_EDITOR

        return;
#endif
        //print("asdasdasdasdasdasd");

        if (PlayerPrefs.HasKey("GameDatas"))
        {
            //print(PlayerPrefs.GetString("GameDatas"));
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("GameDatas"), gameDatas);
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetString("GameDatas", JsonUtility.ToJson(gameDatas));
        PlayerPrefs.Save();

    }

    void OnApplicationQuit()
    {
        //SaveObject();
        SaveData();
    }


    //public Transform GetFloorParentData()
    //{

    //    if (!GameObject.Find("FloorParent (Clone)"))
    //    {
    //        string floorParentPath = Path.Combine("Assets", "__RotatingSwing", "Prefabs", "FloorParent (Clone).prefab");
    //        Object floorParentClone = AssetDatabase.LoadAssetAtPath(floorParentPath, typeof(GameObject));
    //        GameObject newfloorParentClone = Instantiate((GameObject)floorParentClone);
    //        newfloorParentClone.name = "FloorParent (Clone)";
    //        return newfloorParentClone.transform;
    //    }
    //    else
    //    {
    //        Transform newfloorParentClone = GameObject.Find("FloorParent (Clone)").transform;
    //        return newfloorParentClone;
    //    }

    //    //gameDatas.floorParentControllerSave = newfloorParentClone.transform;
    //}

    //public void SaveFloorParentData(Transform getFloorParent)
    //{


    //    string floorParentPath = Path.Combine("Assets", "__RotatingSwing", "Prefabs", "FloorParent (Clone).prefab");
    //    Object floorParentClone = AssetDatabase.LoadAssetAtPath(floorParentPath, typeof(GameObject));
    //    GameObject newfloorParentClone = Instantiate((GameObject)floorParentClone);
    //    newfloorParentClone.name = "FloorParent (Clone)";

    //    //gameDatas.floorParentControllerSave = newfloorParentClone.transform;

    //    floorParentPath = AssetDatabase.GenerateUniqueAssetPath(floorParentPath);

    //    bool prefabSuccess;
    //    PrefabUtility.SaveAsPrefabAsset(newfloorParentClone, floorParentPath, out prefabSuccess);
    //    if (prefabSuccess == true)
    //        Debug.Log("Prefab was saved successfully");
    //    else
    //        Debug.Log("Prefab failed to save" + prefabSuccess);

    //}


    //public void SaveExitData()
    //{
    //    SaveData();
    //}

    // Also save when the application pauses on mobile devices.
    void OnApplicationPause(bool paused)
    {
        if (paused)
            OnApplicationQuit();
    }
}