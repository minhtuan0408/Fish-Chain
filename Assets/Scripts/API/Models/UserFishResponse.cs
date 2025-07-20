using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // thêm vào
public class UserFishListResponse 
{
    public string message;
    public bool success;
    public List<UserFishData> fishes = new List<UserFishData>();
}
[System.Serializable] // mới bổ sung ?? tại sao cho vào nó lại load được??
public class UserFishData
{
    public int id;
    public int level;
    public float hunger_time;
    public float pos_x;
    public float pos_y;
    public float pos_z;
    public string name;
}