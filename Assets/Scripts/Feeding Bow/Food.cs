using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Value { get; private set; } = 10;

    private float timer;
    private float bobSpeed = 1f;      // Tốc độ nhấp nhô
    private float bobAmount = 0.2f;   // Biên độ nhấp nhô
    private float baseY;              // Vị trí Y ban đầu

    private void Start()
    {
        baseY = transform.position.y;
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y = baseY + Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        transform.position = pos;
    }

    public void Eatting() => Value = -1;
}
