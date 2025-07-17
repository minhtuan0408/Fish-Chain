using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public static FishManager Instance;
    
    public AccountUI AccountShow;
    public int MaxSlot = 10;
    public int AmountFish;

    public List<FishType> SpawnFish;
    private void Awake()
    {
        Instance = this;
        UpdateAmountFish();
    }

    public void UpdateAmountFish()
    {
        AmountFish = transform.childCount;
    }

    
    public bool CheckEmty()
    {
        if (AmountFish < MaxSlot)
        {
            return true;
        }
        return false;
    }
    public void AddFish(string fishName, int level, float posX, float posY, float posZ, float hungerTime)
    {
        print (fishName);
        var fishType = SpawnFish.FirstOrDefault(f => f.FishName == fishName);

        if (fishType == null)
        {
            Debug.LogWarning($"Không tìm thấy loại cá tên: {fishName}");
            return;
        }
        UpdateAmountFish();
        ShowAccountUI();

        var Fish = Instantiate(fishType.FishFrefab, gameObject.transform);
        FishInfo fishInfo = Fish.GetComponent<FishInfo>();
        fishInfo.UpdateInfo(hungerTime_If: hungerTime, level_If: level, posX_If: posX, posY_If: posY, posZ_If: posZ);
        Fish.SetActive(true);
    }

    private void ShowAccountUI()
    {
        string displayName = AccountManager.Instance?.Name ?? "Admin Test";
        string money = (AccountManager.Instance?.money ?? 9999).ToString();
        string slot = $"{AmountFish}/{MaxSlot}";

        AccountShow.Show(name: displayName, slot: slot, money: money);
    }
}

[System.Serializable]
public class FishType
{
    public GameObject FishFrefab;
    public string FishName;
}
