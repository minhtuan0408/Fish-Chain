using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FishAPI
{
    public static IEnumerator GetUserFish(int userID, System.Action<UserFishListResponse> onResponse)
    {
        string url = ApiRoutes.GetUserFish(userID);
        //Debug.Log("URL GetUserFish: " + url);
        yield return ApiClient.Get(url, (result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                UserFishListResponse response = JsonUtility.FromJson<UserFishListResponse>(result); // Ôn lại
                onResponse?.Invoke(response);
            }
            else
            {
                onResponse?.Invoke(new UserFishListResponse
                {
                    success = false,
                    message = "Không có phản hồi từ server"
                }); 
            }
        });
    }

    public static IEnumerator AddNewFish(string fishName, int userID, int level, System.Action<AddFishResponse> onResponse)
    {
        string url = ApiRoutes.AddFish(fishName,userID,level);

        AddFishRequest newFish = new AddFishRequest
        {
            owner_id = userID,
            level = level,
            name = fishName
        };
        string packed = JsonUtility.ToJson(newFish);
        yield return ApiClient.Post(url, packed, (result) =>
        {
            Debug.Log("Raw JSON:\n" + result);
            if (!string.IsNullOrEmpty(result)) {
                AddFishResponse response = JsonUtility.FromJson<AddFishResponse>(result);
                onResponse?.Invoke(response);
            }
            else
            {
                Debug.Log("Lỗi ở đây");
                AddFishResponse response = new AddFishResponse
                {
                    success = false
                };
                onResponse?.Invoke(response);
            }
        });
    }
    public static IEnumerator UpdateFish(int fishID, int level, float hungryTime, System.Action<AddFishResponse> onResponse)
    {
        string url = ApiRoutes.UpdateFish(fishID,level,hungryTime);

        UpdateFishRequest fish = new UpdateFishRequest
        {
            id = fishID,
            level = level,
            hungerTime = hungryTime
        };

        string json = JsonUtility.ToJson(fish);
        yield return ApiClient.Put(url, json, (result) =>
        {
            if (string.IsNullOrEmpty(result)) 
            {
                AddFishResponse response = JsonUtility.FromJson<AddFishResponse>(result);
                onResponse?.Invoke(response);
            }
            else
            {
                AddFishResponse response = new AddFishResponse
                {
                    success = false,
                };
                onResponse?.Invoke(response);
            }
        });
    }
    public static IEnumerator DeleteFish(int fishID, System.Action<BaseResponse> onResponese) 
    {
        string url = ApiRoutes.DeleteFish(fishID);

        yield return ApiClient.Delete(url, (result) =>
        {
            if (!string.IsNullOrEmpty(result)) 
            {
                BaseResponse response = JsonUtility.FromJson<BaseResponse>(result);
                onResponese?.Invoke(response);
            }
            else
            {
                Debug.Log("Sai ở đây");
                BaseResponse response = new BaseResponse
                {
                    success = false,
                    message = "Chưa xoá được"
                };
            }
        });
    }


}
