using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject bg;
    void OnEnable()
    {

        GameManager.onLevelWin += ShowUI;
    }
    void Awake()
    {
        bg = gameObject.transform.GetChild(0).gameObject;
    }
    void OnDestroy()
    {
        GameManager.onLevelWin -= ShowUI;
    }
    public void ShowUI()
    {
        if (bg != null)
        {
            bg.SetActive(true);
        }
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
