using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { Start, playing, GameOver, Win }
    public GameState gameState = GameState.Start;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        gameState = GameState.Start;
    }

    public void Update()
    {
        switch (gameState)
        {
            case GameState.Start:
                {
                    UIManager.Instance.Startgame();
                    break;

                }
            case GameState.playing:
                {
                    UIManager.Instance.playingGame();
                    break;
                }
            case GameState.GameOver:
                {
                    break;
                }
            case GameState.Win:
                {
                    UIManager.Instance.GameWin();
                    break;
                }
        }
    }

    public void StartGame()
    {
        gameState = GameState.playing;
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }

    public void Wingame()
    {
        gameState = GameState.Win;
    }

}
