using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        LocateLifeJacket,
        WearLifeJacket,
        SecureBuckle,
        Inflate,
        Completed
    }

    public GameState currentState { get; private set; }
    public delegate void OnStateChangeHandler(GameState newState);
    public event OnStateChangeHandler OnStateChanged;

    void Start()
    {
        SetState(GameState.Intro);  
    }

    public void SetState(GameState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            OnStateChanged?.Invoke(newState); 
        }
    }

    public void CompleteStep()
    {
        SetState((GameState)((int)currentState + 1)); 
    }

    void Update()
    {
        Debug.Log("Step:" + currentState);
    }
}