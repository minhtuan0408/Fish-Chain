using UnityEngine;

public class IldleState : State
{
    public IldleState(Fish Fish, StateMachine stateMachine, FishData fishData) : base(Fish, stateMachine, fishData)
    {
    }
    private int MaxTimeMove;
    private float CurrentTime;

    private float timer;
    private float bobSpeed = 2f;      // Tốc độ nhấp nhô
    private float bobAmount = 0.2f;   // Biên độ nhấp nhô
    private float baseY;              // Vị trí Y ban đầu

    public override void Enter()
    {
        MaxTimeMove = Random.Range(3, 15);
        CurrentTime = 0;

        baseY = fish.transform.position.y;

        if (fish.HungryTime > fish.Type.MaxHunger)
            Debug.Log("Bật thông báo cá đói");
    }

    public override void Update()
    {
        base.Update();

        if (fish.Food.Value > 1 && fish.HungryTime >= fish.Type.MaxHunger) 
            stateMachine.ChangeState(fish.HungryState);


        if (CurrentTime > MaxTimeMove) 
            stateMachine.ChangeState(fish.MoveState);
        CurrentTime += Time.deltaTime;

        Idle();
    }

    public void Idle()
    {
        Vector3 pos = fish.transform.position;
        pos.y = baseY + Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        fish.transform.position = pos;
    }
    
}
