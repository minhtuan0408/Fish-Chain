using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "Fish/Shop Data")]
public class ShopData : ScriptableObject
{
    public List<ShopItem> ShopItems;
}

[System.Serializable]
public class ShopItem // struct không chứa được GameObject
{
    public string name;
    public int price;
    public Sprite icon;
    public string description;
    public GameObject prefab;
}