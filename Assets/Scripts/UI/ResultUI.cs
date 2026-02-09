using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject bg;
    void Awake()
    {
        GameManager.onLevelWin += ShowUI;
    }
    void OnDestroy()
    {
        GameManager.onLevelWin -= ShowUI;
    }
    public void ShowUI()
    {
        bg.SetActive(true);
    }
    public void HideUI()
    {
        bg.SetActive(false);
    }
    public void OnNextLevelClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
