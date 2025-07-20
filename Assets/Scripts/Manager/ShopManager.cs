using System;
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
            // trừ tiền trên này
            if (AccountManager.Instance.EnoughMoney(Item.PriceValue) && FishManager.Instance.CheckEmty())
            {
                int IDUser = AccountManager.Instance.id;
                
                AuthManager.Instance.TryAddNewFish(Item.Name.text, IDUser, 1, (responese) =>
                {
                    if (responese.success)
                    {
                        AccountManager.Instance.SpendMoney(Item.PriceValue);
                        // lưu lên API
                        FishManager.Instance.AddFish(Item.Name.text, level: 1, posX: 0, posY: 0, posZ: 0, hungerTime: 0, responese.id);
                        ResourceManager.Instance.UpdateMoneyAPI(IDUser, AccountManager.Instance.Money);
                    }
                });

                //FishManager.Instance.UpdateAmountFish(); 
                //FishManager.Instance.AddFish(Item.Name.text, level: 1, posX: 0, posY: 0, posZ: 0, hungerTime: 0);
                //Debug.Log(Item.Name.text);
                //AuthManager.Instance.TryAddNewFish(Item.Name.text, IDUser, 1);
            }
           
        }
        else
        {
            FishManager.Instance.AddFish(Item.Name.text, level: 1, posX: 0, posY: 0, posZ: 0, hungerTime: 0, 0);
        }

        FishManager.Instance.UpdateAmountFish();
    }
    public void Sell(int fishID)
    {
        AuthManager.Instance.TryDeleteFish(fishID, (Responese) =>
        {
            if (Responese.success)
            {
                FishInfo fishInfo = UIManager.fishInfo;
                int IDUser = AccountManager.Instance.id;
                Destroy(fishInfo.gameObject);
                ReceiveMoney(fishInfo.Price);
                FishManager.Instance.UpdateAmountFish();
                print("Tiền trước thay đổi : " + AccountManager.Instance.Money);
                ResourceManager.Instance.UpdateMoneyAPI(IDUser, AccountManager.Instance.Money);
            }
            else
            {
                Debug.Log("Chưa bán được cá");
            }
        });
        FishManager.Instance.UpdateAmountFish();
    }


    // chỉ add khi kết nối API thành công
    public void ReceiveMoney(int value)
    {
        int IDUser = AccountManager.Instance.id;
        AccountManager.Instance.AddMoney(value);

    }
}
