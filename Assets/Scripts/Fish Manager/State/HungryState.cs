using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HungryState : State
{
    public HungryState(Fish Fish, StateMachine stateMachine, FishData fishData) : base(Fish, stateMachine, fishData)
    {
    }
    private float bobSpeed = 5f;      // Tốc độ nhấp nhô
    private float bobAmount = 0.2f;   // Biên độ nhấp nhô
    private float baseY;              // Vị trí Y ban đầu
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Đói");
        fish.StartCoroutine(MoveToFood());
        
    }

    IEnumerator MoveToFood()
    {
        if (fish.Food.Value < 1) { 
            stateMachine.ChangeState(fish.IldleState);
            yield break;
        }
        Direction();
        while (Vector2.Distance (fish.transform.position, fish.Food.transform.position) > 1)
        {
            MoveTo(target: fish.Food.transform.position);
            yield return null;
        }

        yield return Eat();
    }

    IEnumerator Eat()
    {
        float eatTime = 0;
        baseY = fish.transform.position.y;
        while (eatTime < 2f)
        {
            eatTime += Time.deltaTime;

            Vector3 pos = fish.transform.position;
            pos.y = baseY + Mathf.Sin(Time.time * bobSpeed) * bobAmount;
            fish.transform.position = pos;

            yield return null;
        }
        Debug.Log("Ăn");
        ResetHungryTime();
        stateMachine.ChangeState(fish.MoveState);

    }
    public void ResetHungryTime()
    {
        fish.HungryTime = 0;
    }

    public void MoveTo(Vector3 target)
    {
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, target, Time.deltaTime * 5f);
    }
    public void Direction()
    {
        float distance = fish.transform.position.x - fish.Food.transform.position.x;
        if (distance > 0)
            fish.sp.flipX = true;
        else
            fish.sp.flipX = false;
    }
}
