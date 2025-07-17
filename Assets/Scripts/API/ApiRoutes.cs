using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
