using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject bg;
    void Awake()
    {
        GameManager.onGameOver += ShowUI;
    }
    void OnDestroy()
    {
        GameManager.onGameOver -= ShowUI;
    }
    public void ShowUI()
    {
        bg.SetActive(true);
    }
    public void HideUI()
    {
        bg.SetActive(false);
    }
    public void OnReplayClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
