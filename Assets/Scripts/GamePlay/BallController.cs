using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float rotationSpeed = 100f;
    public float raycastDistance = 100f;
    public LayerMask raycastMask = -1;
    public Rigidbody rb;
    public float shootForce = 10f;
    public UnityEvent onLevelWin;
    public UnityEvent onGameOver;

    private float currentRotation = 0f;
    private bool isAiming = true;
    private Vector3 aimDirection = Vector3.forward;


    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }


        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }


    void Update()
    {
        if (!isAiming)
            return;


        currentRotation += rotationSpeed * Time.deltaTime;
        if (currentRotation >= 360f)
        {
            currentRotation -= 360f;
        }


        aimDirection = new Vector3(Mathf.Cos(currentRotation * Mathf.Deg2Rad), 0, Mathf.Sin(currentRotation * Mathf.Deg2Rad)).normalized;

        Vector3 startPoint = transform.position;


        Vector3 endPoint = startPoint + aimDirection * raycastDistance;

        if (Physics.Raycast(startPoint, aimDirection, out RaycastHit hit, raycastDistance, raycastMask))
        {
            endPoint = hit.point;
        }


        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
        }
    }

    public void Shoot()
    {
        if (!isAiming)
            return;

        isAiming = false;


        if (lineRenderer != null)
            lineRenderer.enabled = false;


        if (rb != null)
        {
            Vector3 force = aimDirection.normalized * shootForce;
            rb.AddForce(force, ForceMode.Impulse);
        }
    }


    public void ResetAiming()
    {
        isAiming = true;
        if (lineRenderer != null)
            lineRenderer.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }

            isAiming = true;
            if (lineRenderer != null)
                lineRenderer.enabled = true;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }

            if (onLevelWin != null)
                GameManager.onLevelWin?.Invoke();
            else
                Debug.Log("Level Win: Goal reached");
        }

        if (collision.gameObject.CompareTag("DeadLine"))
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }

            if (onGameOver != null)
                GameManager.onGameOver?.Invoke();
            else
                Debug.Log("Game Over: Ball fell off deadline");
        }
    }

}
