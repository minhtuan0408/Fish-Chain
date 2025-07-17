using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "Fish/Fish Data")]
public class FishData : ScriptableObject
{
    public string Fish;
    public float Speed;
    public float MaxLevel;
    public float MaxHunger;
    public int Cost;

    [Header("Normalized Range (0–1): fraction of screen space")]
    [Range(0f, 1f)] public float xRangeMin = 0f;
    [Range(0f, 1f)] public float xRangeMax = 1f;
    [Range(0f, 1f)] public float yRangeMin = 0f;
    [Range(0f, 1f)] public float yRangeMax = 1f;

    private float xLimit = 0;
    private float yLimit = 0;

    public void CalculateLimitFromCamera()
    {
        yLimit = Camera.main.orthographicSize;
        xLimit = yLimit * Screen.width / Screen.height;
    }
    public float MinX => Mathf.Lerp(-xLimit, xLimit, xRangeMin);
    public float MaxX => Mathf.Lerp(-xLimit, xLimit, xRangeMax);
    public float MinY => Mathf.Lerp(-yLimit, yLimit, yRangeMin);
    public float MaxY => Mathf.Lerp(-yLimit, yLimit, yRangeMax);
}
// Các lo?i Type cá;
//  S?ng dý?i ðáy : 
//  Bõi theo ðàn :
//  Bõi cá nhân :
//  Lý?i di chuy?n :


