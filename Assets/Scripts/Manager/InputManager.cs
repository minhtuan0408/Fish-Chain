using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask fishLayer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, fishLayer);
            if (hit.collider != null)
            {
                Fish fish = hit.collider.GetComponent<Fish>();
                if (fish != null)
                {
                    UIManager.fishInfo = fish.Info.ShowInfo();
                }
            }
            else
            {
                UIManager.Instance.HideAll();
            }
        }

    }
}
