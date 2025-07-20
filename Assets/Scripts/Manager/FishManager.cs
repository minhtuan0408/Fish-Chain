using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public static FishManager Instance;
    
    public AccountUI AccountShow;
    public int MaxSlot = 10;
    public int AmountFish {get; private set;}

    public List<FishType> SpawnFish;
    private void Awake()
    {
        Instance = this;
        UpdateAmountFish();
    }
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            LoadAndSpawnFish(AccountManager.Instance.id);
            
        }
    } 
    public void UpdateAmountFish()
    {
        AmountFish = transform.childCount;

        UIManager.AccountUI.ShowAccountUI();
    }

    
    public bool CheckEmty()
    {
        if (AmountFish < MaxSlot)
        {
            return true;
        }
        return false;
    }
    /// load từ data (sửa lại) ---- không được truyền giá trị khi mới thêm vào
    public void AddFish(string fishName, int level, float posX, float posY, float posZ, float hungerTime, int fishID)
    {
        var fishType = SpawnFish.FirstOrDefault(f => f.FishName == fishName);

        if (fishType == null)
        {
            Debug.LogWarning($"Không tìm thấy loại cá tên: {fishName}");
            return;
        }

        var Fish = Instantiate(fishType.FishFrefab, gameObject.transform);
        FishInfo fishInfo = Fish.GetComponent<FishInfo>();
        fishInfo.UpdateInfo(hungerTime_If: hungerTime, level_If: level, posX_If: posX, posY_If: posY, posZ_If: posZ, fishID: fishID);
        Fish.SetActive(true);
        UpdateAmountFish();
    }


    public void LoadAndSpawnFish(int userId)
    {
        //print("Loading here");
        var fishList = ResourceManager.Instance.CurrentFishList.fishes;
        if (fishList == null) print("Chưa gán");
        foreach (var fish in fishList)
        {
            //Debug.Log(fish.name + fish.id);
            AddFish(
                fishName: fish.name,
                level: fish.level,
                posX: fish.pos_x,
                posY: fish.pos_y,
                posZ: fish.pos_z,
                hungerTime: fish.hunger_time,
                fish.id
                );
        }
        UpdateAmountFish();
    }

}

[System.Serializable]
public class FishType
{
    public GameObject FishFrefab;
    public string FishName;
}

