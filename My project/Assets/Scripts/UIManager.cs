using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameWinPanel;
    public GameObject scorepanel;
    public static UIManager Instance {get; private set;}
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Startgame()
    {
        startPanel.SetActive(true);
        gameWinPanel.SetActive(false);
        scorepanel.SetActive(false);
    }

    public void playingGame()
    {
        startPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        scorepanel.SetActive(true);
    }

    public void GameWin()
    {
        startPanel.SetActive(false);
        gameWinPanel.SetActive(true);
        scorepanel.SetActive(false);
    }
}
