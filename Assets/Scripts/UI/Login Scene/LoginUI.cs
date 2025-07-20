using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;

    public void OnLoginButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("⚠️ Thiếu thông tin đăng nhập");
            return;
        }
        AuthManager.Instance.TryLogin(username, password, (success) =>
        {
            if (success)
            {
                AccountManager.Instance.LoadInfo(username);
            }
            else
            {
                Debug.LogWarning("Đăng nhập thất bại");
            }
        });
    }
}
