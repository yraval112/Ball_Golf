using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    public void OnShootBtnClick()
    {
        BallController ballController = FindObjectOfType<BallController>();
        if (ballController != null)
        {
            ballController.Shoot();
        }
        if (GameManager.Instance.cameraManager != null)
        {
            GameManager.Instance.cameraManager.ResetCamera();
        }
    }
}
