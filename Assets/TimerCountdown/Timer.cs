using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private float originalTime;

    private float pulseTimer;
    private bool isPulsing;

    void Start()
    {
        originalTime = remainingTime; // Store the original time for resetting the pulse
    }

    void Update()
    {
        // Countdown logic
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0; // Ensure the timer doesn't go negative
        }

        // Change the timer color when it's below 30 seconds
        if (remainingTime < 30)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white; // Reset color to white when above 30 seconds
        }

        // Pulsing effect for the last 10 seconds
        if (remainingTime < 10 && !isPulsing)
        {
            StartCoroutine(PulseEffect());
            isPulsing = true;
        }

        // Update the timer display
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Coroutine for pulsing effect on the timer text
    private IEnumerator PulseEffect()
    {
        while (remainingTime < 10)
        {
            // Pulsing effect: change the scale of the timer text
            timerText.transform.localScale = Vector3.one * Mathf.PingPong(Time.time * 0.5f, 0.1f + 0.05f) + Vector3.one;
            yield return null;
        }

        // Reset scale once pulsing effect ends
        timerText.transform.localScale = Vector3.one;
    }
}
