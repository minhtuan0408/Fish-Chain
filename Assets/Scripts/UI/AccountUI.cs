using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccountUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI FishAmount;
    public TextMeshProUGUI Money;

    private void Awake()
    {

    }

    public void Show(string name, string slot, string money)
    {
        Name.text = "aaa";
        FishAmount.text = slot;
        Money.text = money;
    }
}
