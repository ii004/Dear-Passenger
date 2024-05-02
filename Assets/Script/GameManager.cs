using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float stepDelay = 0.3f;
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
    
    private int _currentStateIndex = 0;
    private int _GameStateCount;
    
    void Awake()
    {
        _GameStateCount = System.Enum.GetNames(typeof(GameState)).Length;
    }
    
    void Start()
    {
        StartIntro(); 
    }
    
    private void StartIntro()
    {
        audioManager.PlayVoiceOver(_currentStateIndex, OnIntroVoiceOverComplete);
    }
    
    private void OnIntroVoiceOverComplete()
    {
        StartCoroutine(DelayedNextState(stepDelay)); 
    }
    
    public void SetState(GameState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            OnStateChanged?.Invoke(newState);
            if (newState == GameState.Completed)
            {
                audioManager.PlayVoiceOver(GetVoiceOverIndexForState(newState), OnFinalVoiceOverComplete);
            }
            else
            {
                audioManager.PlayVoiceOver(GetVoiceOverIndexForState(newState), OnVoiceOverComplete);
            }
        }
    }

    public IEnumerator DelayedNextState(float delay)
    {
        yield return new WaitForSeconds(delay);  
        NextState(); 
    }

    public void NextState()
    {
        _currentStateIndex++;
        if (_currentStateIndex >= _GameStateCount)
        {
            Debug.Log("All states completed.");
            return;
        }
        SetState((GameState)_currentStateIndex); 
    }

    private void OnVoiceOverComplete()
    {
    }
    
    private int GetVoiceOverIndexForState(GameState state)
    {
        return (int)state;
    }
    
    private void OnFinalVoiceOverComplete()
    {
        Debug.Log("Training complete! Final voice-over finished.");
    }
}