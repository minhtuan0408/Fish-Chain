using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public ShopTile ShopTilePrefab;
    public ShopData ShopData;

    public Transform content;

    public Transform FishManagerTransform;
    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (var itemData in ShopData.ShopItems)
        {
            int cnt = 0;
            cnt++;
            var Item = Instantiate(ShopTilePrefab, content);
            Item.name = $"Item {cnt}";
            Item.SetModel(itemData);
        }
    }

    public void Buy(ShopTile Item)
    {
        if (AccountManager.Instance)
        {
            if (AccountManager.Instance.MinusMoney(Item.PriceValue) && FishManager.Instance.CheckEmty())
            {
                FishManager.Instance.AddFish(Item.Name.text, level: 1, posX: 0, posY: 0, posZ: 0, hungerTime: 0);
            }
        }
        else
        {
            FishManager.Instance.AddFish(Item.Name.text, level: 1, posX: 0, posY: 0, posZ: 0, hungerTime: 0);
        }
        
    }
}
