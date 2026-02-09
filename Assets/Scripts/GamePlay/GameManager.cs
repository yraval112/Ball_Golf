using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action onLevelWin;
    public static Action onGameOver;

    public CameraManager cameraManager;

    public ResultUI resultUI;
    public GameOverUI gameOverUI;

    void OnEnable()
    {
        onLevelWin += ShowResultUI;
        onGameOver += ShowGameOverUI;
        if (cameraManager == null)
        {
            cameraManager = FindObjectOfType<CameraManager>();
        }
        if (resultUI == null)
        {
            resultUI = FindObjectOfType<ResultUI>();
        }
        if (gameOverUI == null)
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
        }

    }
    void OnDestroy()
    {
        onLevelWin -= ShowResultUI;
        onGameOver -= ShowGameOverUI;
    }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);



    }


    public void ShowResultUI()
    {
        // Refresh reference if it's null (happens when loading new scenes)
        if (resultUI == null)
        {
            resultUI = FindObjectOfType<ResultUI>();
        }

        if (resultUI != null)
        {
            resultUI.ShowUI();
        }
    }

    public void ShowGameOverUI()
    {
        // Refresh reference if it's null (happens when loading new scenes)
        if (gameOverUI == null)
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
        }

        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(true);
        }
    }
}
