using UnityEngine;

public class CoinIdleAnimation : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;

    [Header("Bob Settings")]
    public bool enableBob = true;
    public float bobSpeed = 2f;
    public float bobHeight = 0.25f;

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position for the bobbing effect
        initialPosition = transform.position;
    }

    void Update()
    {
        // Rotate the coin continuously
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Bob up and down if enabled
        if (enableBob)
        {
            float newY = initialPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}