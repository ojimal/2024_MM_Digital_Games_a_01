using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] AudioSource timerEndSound;
    [SerializeField] GameEnding gameEnding; // Reference to GameEnding script

    bool hasPlayedEndSound = false;
    bool isPulsing = false;
    void Start()
    {
        if (gameEnding == null)
        {
            gameEnding = FindObjectOfType<GameEnding>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            // Start pulsing effect when time is below 10 seconds
            if (remainingTime < 10 && !isPulsing)
            {
                StartCoroutine(PulseText());
            }

            if (remainingTime < 30)
            {
                timerText.color = Color.red;
            }
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerEndSound.Play();
            hasPlayedEndSound = true;

            // Trigger the end game sequence in GameEnding
            if (gameEnding != null)
            {
                gameEnding.TriggerEndGame();
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator PulseText()
    {
        isPulsing = true;

        while (remainingTime > 0 && remainingTime < 10)
        {
            // Scale up
            timerText.transform.localScale = Vector3.one * 1.2f;
            yield return new WaitForSeconds(0.5f);

            // Scale down
            timerText.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(0.5f);
        }

        // Reset scale after pulsing ends
        timerText.transform.localScale = Vector3.one;
        isPulsing = false;
    }
}
