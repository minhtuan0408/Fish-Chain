using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopTile : MonoBehaviour, IPointerClickHandler
{
    private ShopItem _model;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public int PriceValue;
    public Image Image;
    public GameObject ItemPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShopManager.Instance.Buy(this);
    }
    public void SetModel(ShopItem model)
    {
        _model = model;
        Name.text = model.name;
        Price.text = model.price.ToString();
        PriceValue = model.price;
        Image.sprite = model.icon;
        ItemPrefab = model.prefab;
    }

}
