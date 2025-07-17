using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfomationPanel : MonoBehaviour
{
    [SerializeField] private Image imageUI;
    [SerializeField] private TextMeshProUGUI textMeshPro ;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
