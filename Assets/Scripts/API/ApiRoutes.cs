using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ApiRoutes
{
    public static string Base = "https://localhost:7012";
    public static string Login(string username, string password)
    {
        return $"{Base}/api/User/Login?account={username}&password={password}";
    }
    public static string Register()
    {
        return $"{Base}/api/User/Register";
    }
    public static string GetInfo(string username)
    {
        return $"{Base}/api/User/Info?user={username}";
    }
    public static string GetUserFish(int IDUsser) 
    {
    /// "https://localhost:7012/api/Fish/GetFish?idUser=1"
        return $"{Base}/api/Fish/GetListFish?idUser={IDUsser}";
    }
    public static string AddFish(string fishName, int userID, int level) 
    {
    /// https://localhost:7012/api/Fish/AddFish?name=Green%20Fish&ownerID=1&level=3
        return $"{Base}/api/Fish/AddFish?name={fishName}&ownerID={userID}&level={level}";
    }
    public static string UpdateFish(int fishID, int level, float hungerTime )
    {
        ///https://localhost:7012/api/Fish/UpdateFish?id=3&level=2&hungerTime=15
        return $"{Base}/api/Fish/UpdateFish?id={fishID}&level={level}&hungerTime={hungerTime}";
    }
    public static string DeleteFish(int fishID) 
    {
        return $"{Base}/api/Fish/RemoveFish?id={fishID}";
    }
    public static string UpdateUserMoney(int id, int money)
    {
        return $"{Base}/api/User/UpdateUser?id={id}&money={money}";
    }
}
