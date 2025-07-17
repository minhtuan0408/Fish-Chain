using UnityEngine;

[CreateAssetMenu(fileName = "ActiveRangeData", menuName = "ScriptableObjects/ActiveRangeData")]
public class ActiveRangeData : ScriptableObject
{
    [Header("Normalized Range (0–1): fraction of screen space")]
    [Range(0f, 1f)] public float xRangeMin = 0f;  
    [Range(0f, 1f)] public float xRangeMax = 1f;
    [Range(0f, 1f)] public float yRangeMin = 0f;  
    [Range(0f, 1f)] public float yRangeMax = 1f;

    private float xLimit;
    private float yLimit;

    private void OnEnable()
    {
        CalculateLimitFromCamera();
    }

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
