using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public partial class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

public partial class ResourceManager
{
    public UserData UserData { get; private set; } = new UserData();
    public UserFishListResponse CurrentFishList { get; private set; } = new UserFishListResponse();
}

    public partial class ResourceManager
    {
    public void UpdateMoneyAPI(int id, int money)
    {
        AuthManager.Instance.TryUpdateUserMoney(id, money, (Responese) =>
        {
            if (Responese.success)
            {
                GetInfoAPI(AccountManager.Instance.Name);
                print("Tiển sau khi lưu " + AccountManager.Instance.Money);
            }
            else
            {
                Debug.Log("Chưa bán được cá");
            }
        });
    }
    public void GetInfoAPI(string Username)
    {
        AuthManager.Instance.TryGetUserInfo(Username, (json, response) =>
        {
            if (response.success)
            {
                UserData data = new UserData
                {
                    ID = response.id,
                    UserName = response.username,
                    Money = response.money
                };
                LoadUserData(data);
                AccountManager.Instance.SetUser();
                LoadFishData(data.ID);
                UIManager.AccountUI.ShowAccountUI();
                FishManager.Instance.UpdateAmountFish();
            }
            else
            {
                Debug.LogWarning("Không lấy được thông tin user: " + response.message);
            }
        });
    }


    public void LoadUserData(UserData data)
    {
        UserData.ID = data.ID;
        UserData.UserName = data.UserName;
        UserData.Money = data.Money;
    }
    public UserData GetUserData()
    {
        return UserData;
    }

    public void LoadFishData(int userId)
    {
        AuthManager.Instance.TryGetUserFishList(userId, (json, response) =>
        {
            if (response.success)
            {
                CurrentFishList = response;
                //foreach (var fish in response.fishes)
                //{
                //    Debug.Log($"- {fish.name} tại ({fish.pos_x}, {fish.pos_y}, {fish.pos_z}) \n");
                //}
            }
            else
            {
                Debug.LogWarning("Không load được cá: " + response.message);
            }
        });
    }
}
