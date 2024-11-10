using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public AudioSource backgroundMusic;


    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    bool m_IsTimerEnded; // New flag to check if timer reached zero
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    // New method to trigger end of game when timer reaches zero
    public void TriggerEndGame()
    {
        m_IsTimerEnded = true;
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio, backgroundMusic);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio, backgroundMusic);
        }
        else if (m_IsTimerEnded) // Check if timer has ended
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio, backgroundMusic);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource, AudioSource backgroundMusic)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            backgroundMusic.Stop();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
