using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected Fish fish;
    protected StateMachine stateMachine;
    protected FishData fishData;
    protected float timeSinceDirectionChange;
    public State(Fish Fish, StateMachine stateMachine, FishData fishData)
    {
        this.fish = Fish;
        this.stateMachine = stateMachine;
        this.fishData = fishData;
    }
    public virtual void Enter()
    {
    }
    public virtual void Exit() 
    {
    }
    public virtual void Update()
    {
    }
}
