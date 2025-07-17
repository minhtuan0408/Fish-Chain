using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    StateMachine stateMachine;

    public FishData Type;
    public FishInfo Info {get; private set;}
    public float HungryTime;
    public IldleState IldleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public HungryState HungryState;
    public SpriteRenderer sp {get; private set;}
    public Food Food { get; private set; }


    private void Awake()
    {
        Info = GetComponent<FishInfo>();
        sp = GetComponent<SpriteRenderer>();
        Food = GameObject.FindGameObjectWithTag("Food").GetComponent<Food>();
        Type.CalculateLimitFromCamera();

        stateMachine = new StateMachine();
        IldleState = new IldleState(this, stateMachine, Type);
        MoveState = new MoveState(this, stateMachine, Type);
        HungryState = new HungryState(this, stateMachine, Type);
    }
    private void Start()
    {
        stateMachine.Init(IldleState);
    }
    private void Update()
    {
        HungryTime += Time.deltaTime;
        stateMachine.currentState.Update();
    }
}

