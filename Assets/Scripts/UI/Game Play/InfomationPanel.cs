using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfomationPanel : MonoBehaviour
{
    [SerializeField] private Image imageUI;
    [SerializeField] private TextMeshProUGUI textMeshPro ;
    [SerializeField] private Button button;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        button.onClick.AddListener(Sell);
        Debug.Log("Đã gắn hàm Sell vào nút");
    }

    // quên public =vv
    public void Sell()
    {
        FishInfo fishInfo = UIManager.fishInfo;
        
        if (fishInfo != null)
        {
            if (GameManager.Instance != null)
            {
                int id = fishInfo.fishID;
                ShopManager.Instance.Sell(id);
                Debug.Log("Thực hiện");
            }
            else
            {
                Destroy(fishInfo.gameObject);
            }
        }
        UIManager.Instance.HideAll();
    }
    public void ShowUIInfomation()
    {
        anim.SetBool("isInfo", true);
    }
    public void HideUIInfomation()
    {
        anim.SetBool("isInfo", false);
    }
    public void UpdateInfomation(Sprite image, string info)
    {
        imageUI.sprite = image;
        textMeshPro.text = info;
    }
}
