using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KichenGameManager : MonoBehaviour
{
    public static KichenGameManager Instance {get; private set;}
    public event EventHandler OnStateChanged;
    private enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    private State state;
    private float WaitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;
    private void Awake() {
        Instance = this;
        state = State.WaitingToStart;
    }
    private void Update() {
        switch(state){
            case State.WaitingToStart:
                WaitingToStartTimer -= Time.deltaTime;
                if(WaitingToStartTimer < 0f){
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if(countdownToStartTimer < 0f){
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer < 0f){
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }
    public bool IsGamePlaying(){
        return state == State.GamePlaying;
    }
    public bool IsCountdownToStartActive(){
        return state == State.CountdownToStart;
    }
    public float GetCountdownToStartTimer(){
        return countdownToStartTimer;
    }
    public bool IsGameOver(){
        return state == State.GameOver;
    }
}
