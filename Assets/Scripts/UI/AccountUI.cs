using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccountUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI FishAmount;
    public TextMeshProUGUI Money;

    private void Show(string name, string slot, string money)
    {
        Name.text = "aaa";
        FishAmount.text = slot;
        Money.text = money;
    }

    public void ShowAccountUI()
    {
        string displayName = AccountManager.Instance?.Name ?? "Admin Test";
        string money = (AccountManager.Instance?.money ?? 9999).ToString();
        string slot = $"{FishManager.Instance.AmountFish}/{FishManager.Instance.MaxSlot}";
        print(FishManager.Instance.AmountFish);
        Show(name: displayName, slot: slot, money: money);
    }
}
