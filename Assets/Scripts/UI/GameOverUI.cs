using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject bg;
    void OnEnable()
    {
        GameManager.onGameOver += ShowUI;

    }
    void Awake()
    {
        bg = gameObject.transform.GetChild(0).gameObject;
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
