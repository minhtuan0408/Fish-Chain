using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInfo : MonoBehaviour
{
    private Fish fish;
    private int fishID = 0;
    int fishLevel = 0;
    private float fishHungerTime;
    private float fishPosX;
    private float fishPosY;
    private float fishPosZ;
    private string infoThisFish = "";

    private void Awake()
    {
        fish = GetComponent<Fish>();
    }
    private void GetDetails()
    {
        print($"Level : {fishLevel}");
        print($"Level : {fish.Type.MaxLevel}");
        print($"Level : {fish.Type.Cost}");
        int price = fishLevel >= fish.Type.MaxLevel ? fish.Type.Cost*2 : fish.Type.Cost;
        infoThisFish =  $"{fish.Type.name} \n" +
                        $"Level :{fishLevel}/{fish.Type.MaxLevel} \n" +
                        $"Sell : {price}";
    }
    public void ShowInfo()
    {
        GetDetails();
        UIManager.Instance.ShowPanel(UIPanelType.Information);
        UIManager.InfomationPanel.UpdateInfomation(image: fish.sp.sprite, info: infoThisFish);
    }
    public void UpdateInfo(float hungerTime_If, int level_If, float posX_If, float posY_If, float posZ_If)
    {
        fishHungerTime = hungerTime_If;
        fishLevel = level_If;
        fishPosX = posX_If;
        fishPosY = posY_If;
        fishPosZ = posZ_If;
    }

}
