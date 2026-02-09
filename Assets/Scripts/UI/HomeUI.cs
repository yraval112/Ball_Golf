using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    public void OnPlaybtnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
