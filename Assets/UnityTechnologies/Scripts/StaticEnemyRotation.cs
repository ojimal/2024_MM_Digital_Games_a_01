using UnityEngine;

public class EnemyObserver : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationAngle = 30f; // Angle to rotate left and right
    public float rotationSpeed = 1f;  // Speed of the rotation
    private float initialYRotation;
    private bool rotatingRight = true;
    void Start()
    {
        // Store the initial Y rotation
        initialYRotation = transform.eulerAngles.y;
    }
    void Update()
    {
        // Calculate the current rotation range
        float targetAngle = rotatingRight ? initialYRotation + rotationAngle : initialYRotation - rotationAngle;
        // Smoothly rotate towards the target angle
        float currentYRotation = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentYRotation, transform.eulerAngles.z);
        // Check if we've reached the target angle and flip direction if so
        if (Mathf.Abs(currentYRotation - targetAngle) < 0.1f)
        {
            rotatingRight = !rotatingRight; // Switch direction
        }
    }
}
