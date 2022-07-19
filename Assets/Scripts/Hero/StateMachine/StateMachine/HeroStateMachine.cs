using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;
    private List<HeroState> _states;

    private void Start()
    {
        CreateStates();
    }

    private void Update()
    {
        _stateMachine.Update();    
    }

    private void CreateStates()
    {
        _states = new List<HeroState>();
        var standingState = new StandingState();
        _states.Add(standingState);

        _stateMachine = new StateMachine(standingState);
    }

    public void ChangeState(HeroState newHeroState)
    {
        _stateMachine.ChangeState(newHeroState);
    }
}
