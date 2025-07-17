using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class AccountManager : MonoBehaviour
{
    public static AccountManager Instance;
    public int money { get; private set; } = 12;
    public string Name {get; private set;}
    public int id { get; private set; }

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

    public void ReceiveMoney(int value) => money += value;

    public bool MinusMoney(int value)
    {
        if (value > money)
            return false;
        money -= value;
        return true;
    }
}

public partial class AccountManager 
{
    public void LogIn(string Username)
    {
        AuthManager.Instance.TryGetUserInfo(Username, (json, response) =>
        {
            if (response.success)
            {
                id = response.id;
                name = response.username;
                money = response.money;

                print (id + name + money);
            }
            else
            {
                Debug.LogWarning("Không lấy được thông tin user: " + response.message);
            }
        });
    }
}
