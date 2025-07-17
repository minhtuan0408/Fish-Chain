using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIPanelType
{
    None,
    Information,
    Shop,
    Feeding
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{  get; private set; }

    [SerializeField] private InfomationPanel infomationPanel;
    [SerializeField] private ShopPanel shopPanel;
    public static InfomationPanel InfomationPanel => Instance.infomationPanel;
    public static ShopPanel ShopPanel => Instance.shopPanel;

    private UIPanelType currentPanel = UIPanelType.None;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowPanel(UIPanelType panelType)
    {
        if (currentPanel == panelType) return;
        HideAll();
        switch (panelType)
        {
            case UIPanelType.Information:
                infomationPanel.ShowUIInfomation();
                break;
            case UIPanelType.Shop:
                shopPanel.ShowShop();
                break;
            case UIPanelType.Feeding:
                break;
        }
        currentPanel = panelType;
    }

    public void HideAll()
    {
        infomationPanel.HideUIInfomation();
        shopPanel.HideShop();
        currentPanel = UIPanelType.None;
    }

}
