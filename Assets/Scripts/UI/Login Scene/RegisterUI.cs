using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField Gmail;
    [SerializeField] private TMP_InputField passwordInput;

    public void RegisterButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string email = Gmail.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("⚠️ Thiếu thông tin đăng nhập");
            return;
        }
        AuthManager.Instance.TryRegister(username, password, email);
    }
}
