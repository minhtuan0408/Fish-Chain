using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class UserData
{
    public int ID;
    public string UserName;
    public int Money;
}

public partial class AccountManager : MonoBehaviour
{
    public static AccountManager Instance;
   
    public int money { get; private set; } = 100;
    public string Name {get; private set;}
    public int id { get; private set; }

    public int Money =>money;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

public partial class AccountManager 
{
    public void LoadInfo(string Username)
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
                ResourceManager.Instance.LoadUserData(data);
                SetUser();
                ResourceManager.Instance.LoadFishData(data.ID);
                GameManager.Instance.LoadNext("GamePlay");
            }
            else
            {
                Debug.LogWarning("Không lấy được thông tin user: " + response.message);
            }
        });
    }

    public void SetUser()
    {
        UserData User = ResourceManager.Instance.GetUserData();
        print ("Tiền lấy trên DATA trước khi gắn " + User.Money);
        money = User.Money;
        Name = User.UserName;
        id = User.ID;
    }
    public void AddMoney(int value)
    {
        print("Cộng tiền");
        money += value;
    }

    
    public bool EnoughMoney(int value)
    {
        if (money > value)
        {
            return true;
        }
        return false;
    }
    public void SpendMoney(int value)
    {
        print("Trừ tiền");
        if (money < value)
        {
            return;
        }
        money -= value;
    }
    //public void LogOut()
    //{
    //    // Xoá session (tuỳ bạn lưu kiểu gì)
    //    AuthManager.Instance.ClearToken();
    //    ResourceManager.Instance.ClearUserData();

    //    // Chuyển về màn login
    //    LoadNext("Login");
    //}
}
