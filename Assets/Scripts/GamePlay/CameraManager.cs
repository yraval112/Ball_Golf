using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform ballTarget;

    [Header("Follow Settings")]
    public float cameraHeight = 10f;
    public float followSmoothTime = 0.2f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 4f;
    public float minZoom = 3f;
    public float maxZoom = 20f;
    public float zoomSmoothTime = 0.2f;

    private Camera cam;

    private Vector3 followVelocity;
    private float zoomVelocity;

    private float currentZoom;
    private float targetZoom;
    private float defaultZoom;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
    }

    void Start()
    {
        if (ballTarget == null)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Player");
            if (ball != null)
                ballTarget = ball.transform;
        }

        defaultZoom = cam.orthographicSize;
        currentZoom = defaultZoom;
        targetZoom = defaultZoom;
    }

    void LateUpdate()
    {
        if (ballTarget == null)
            return;

        Vector3 targetPosition = ballTarget.position + Vector3.up * cameraHeight;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref followVelocity,
            followSmoothTime
        );

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        currentZoom = Mathf.SmoothDamp(
            currentZoom,
            targetZoom,
            ref zoomVelocity,
            zoomSmoothTime
        );

        cam.orthographicSize = currentZoom;
    }

    public void ZoomIn()
    {
        targetZoom -= zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
    }

    public void ZoomOut()
    {
        targetZoom += zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
    }

    public void ResetCamera()
    {
        targetZoom = defaultZoom;
    }
}
