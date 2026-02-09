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


    public void ShowResultUI()
    {
        resultUI.ShowUI();
    }

    public void ShowGameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
    }
}
