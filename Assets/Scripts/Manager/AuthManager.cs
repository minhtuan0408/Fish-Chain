using Unity.VisualScripting;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    public void TryLogin(string user, string pass, System.Action<bool> onResult)
    {
        StartCoroutine(UserAPI.Login(user, pass, (response) =>
        {
            if (response.success)
            {
                Debug.Log("✅ Đăng nhập thành công: " + response.message);
                onResult?.Invoke(true);
            }
            else
            {
                Debug.LogWarning("❌ Lỗi: " + response.message);
                onResult?.Invoke(false);
            }
        }));
    }
    public void TryRegister(string user, string pass, string email)
    {
        StartCoroutine(UserAPI.Register(user, pass, email, (response) =>
        {
            if (response.success)
            {
                Debug.Log("đăng kí thành công " + response.message);
            }
            else
            {
                Debug.LogWarning("❌ Lỗi: " + response.message);
            }
        }));
    }

    public void TryGetUserInfo(string username, System.Action<string, UserInfoResponse> JsonInfo)
    {
        StartCoroutine(UserAPI.GetUserInfo(username, (response) =>
        {
            if (response.success)
            {
                string json = JsonUtility.ToJson(response);
                //Debug.Log($"{json}");

                JsonInfo?.Invoke(json, response);
            }
            else 
            {
                Debug.LogWarning(response.message);

                JsonInfo?.Invoke(null, response);
            }
        }));
    }

    public void TryGetUserFishList(int userID, System.Action<string, UserFishListResponse> JsonUserFishList)
    {
        StartCoroutine(FishAPI.GetUserFish(userID, (response) =>
        {
            if (response.success)
            {
                string json = JsonUtility.ToJson(response);

                // ✅ Gọi callback sau khi load thành công
                JsonUserFishList?.Invoke(json, response);
            }
            else
            {
                Debug.LogWarning(response.message);
                JsonUserFishList?.Invoke(null, response);
            }
        }));
    }

    public void TryAddNewFish(string fishName, int userID, int level, System.Action<AddFishResponse> onResponese)
    {
        StartCoroutine(FishAPI.AddNewFish(fishName, userID, level, (response) => {
            if (!response.success)
            {
                Debug.Log("Lỗi tryaddnewfish");
            }
            onResponese?.Invoke(response);
        }));
    }

    public void TryDeleteFish(int fishID, System.Action<BaseResponse> onResponese)
    {
        StartCoroutine(FishAPI.DeleteFish(fishID, (res) =>
        {
            if (res == null)
            {
                Debug.LogWarning("Không nhận được phản hồi, try ..");
            }
            onResponese?.Invoke(res); // Gọi callback dù thành công hay thất bại
        }));
    }

    public void TryUpdateUserMoney(int ID, int money,System.Action<BaseResponse> onResponese)
    {
        StartCoroutine(UserAPI.UpdateUserMoney(ID,money, (res) =>
        {
            if (res == null)
            {
                Debug.LogWarning("Không nhận được phản hồi, try ..");
            }
            onResponese?.Invoke(res); // Gọi callback dù thành công hay thất bại
        }));
    }
}
