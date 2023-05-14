using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



[CreateAssetMenu(fileName = "GameDatas", menuName = "Kadir/GameDatas", order = 1)]
public class GameDatas : ScriptableObject
{

    [Header("ButtonsPrice")]
    public float addButtonPrice;
    public float mergeButtonPrice;
    public float swingSpeedButtonPrice;

    [Header("Info")]
    public float totalMoneyCount;
    public float towerMoneyCount;
    public float rotateSpeed;
    public float playerHeightValue;
    public float floorHeightValue;

    public int mapId;

    public List<int> mergeList = new List<int>();

    public List<int> floorMoneyInfoList = new List<int>();


    [Button]
    public void ResetGameData()
    {
        Debug.Log("GameData Sıfırlandı");
        addButtonPrice = 1;
        mergeButtonPrice = 4;
        swingSpeedButtonPrice = 50;
        totalMoneyCount = 10;
        towerMoneyCount = 0;
        rotateSpeed = 30;
        playerHeightValue = 14;
        floorHeightValue = 0;
        mapId = 0;
        mergeList.Clear();
        floorMoneyInfoList.Clear();

    }
}
