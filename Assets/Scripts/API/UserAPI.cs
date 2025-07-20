using System.Collections;
using UnityEngine;

public static class UserAPI
{
    public static IEnumerator Login(string username, string password, System.Action<LoginResponse> onResponse)
    {
        string url = ApiRoutes.Login(username, password);

        LoginRequest loginData = new LoginRequest
        {
            username = username,
            password = password,
        };

        string json = JsonUtility.ToJson(loginData);

        yield return ApiClient.Post(url, json, (result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(result);
                onResponse?.Invoke(response);
            }
            else
            {
                LoginResponse response = new LoginResponse
                {
                    success = false,
                    message = "Không có phản hồi"
                };
                onResponse?.Invoke(response);
            }
        });

    }
    public static IEnumerator Register(string username, string password, string gmail, System.Action<RegisterResponse> onResponse)
    {
        string url = ApiRoutes.Register();

        RegisterRequest registerData = new RegisterRequest
        {
            username = username,
            password = password,
            email = gmail
        };


        string json = JsonUtility.ToJson(registerData);

        yield return ApiClient.Post(url, json, (result) =>
        {
            Debug.Log("API Response: " + result);
            if (!string.IsNullOrEmpty(result))
            {
                RegisterResponse response = JsonUtility.FromJson<RegisterResponse>(result);
                onResponse?.Invoke(response);
            }
            else
            {
                RegisterResponse response = new RegisterResponse
                {
                    success = false,
                    message = "Không có phản hồi"
                };
                onResponse?.Invoke(response);
            }
        }
        );
    }
    public static IEnumerator GetUserInfo(string username, System.Action<UserInfoResponse> onResponse)
    {
        string url = ApiRoutes.GetInfo(username);

        //UserInfoRequest InfoData = new UserInfoRequest
        //{
        //    UserName = username
        //};
        //string json = JsonUtility.ToJson(InfoData);
        yield return ApiClient.Get(url, (result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                UserInfoResponse response = JsonUtility.FromJson<UserInfoResponse>(result); // Ôn lại
                onResponse?.Invoke(response);
            }
            else
            {
                onResponse?.Invoke(new UserInfoResponse
                {
                    success = false,
                    message = "Không có phản hồi từ server"
                });
            }
        }); 
    }

    public static IEnumerator UpdateUserMoney(int id, int money, System.Action<BaseResponse> onResponse)
    {
        string url = ApiRoutes.UpdateUserMoney(id, money);
        UserMoney userMoney = new UserMoney
        {
            id = id,
            money = money
        };
        string json = JsonUtility.ToJson(userMoney);
        yield return ApiClient.Put(url, json, (result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                BaseResponse response = JsonUtility.FromJson<BaseResponse>(result);
                onResponse?.Invoke(response);
            }
            else
            {
                BaseResponse response = new BaseResponse
                {
                    success = false
                };
                onResponse?.Invoke(response);
            }
        });
        yield return 0;
    }

}