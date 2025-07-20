using UnityEngine;

public class MoveState : State
{
    private Vector3 target;
    public MoveState(Fish Fish, StateMachine stateMachine, FishData fishData) : base(Fish, stateMachine, fishData)
    {
    }
    public override void Enter()
    {
        base.Enter();
        target = GetRandomDestination();
        //Debug.Log("Move");
        Direction();
    }
    public override void Update()
    {
        base.Update();
        
        if (Vector3.Distance(fish.transform.position, target) < 0.5f)
            stateMachine.ChangeState(fish.IldleState);
        MoveTo(target);
    }
    public Vector3 GetRandomDestination()
    {
        return new Vector3(Random.Range(fishData.MinX, fishData.MaxX), Random.Range(fishData.MinY, fishData.MaxY), 0);
    }
    public void MoveTo(Vector3 target)
    {
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, target, Time.deltaTime * 2f);
    }
    public void Direction()
    {
        float distance = fish.transform.position.x - target.x;
        if (distance > 0)
            fish.sp.flipX = true;
        else
            fish.sp.flipX = false;
    }
}
