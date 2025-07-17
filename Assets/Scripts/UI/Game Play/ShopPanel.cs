using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ShowShop()
    {
        anim.SetBool("isActive", true);
    }
    public void HideShop() 
    {
        anim.SetBool("isActive", false);
    }

    public void OnClickButton()
    {
        UIManager.Instance.ShowPanel(UIPanelType.Shop);
    }
}
