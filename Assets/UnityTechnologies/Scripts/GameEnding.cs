using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
    public TextMeshProUGUI lemonText;
    public int requiredCoins = 10;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            int currentCoins = int.Parse(lemonText.text);
            if (currentCoins >= requiredCoins)
            {
                m_IsPlayerAtExit = true;
            }
            else
            {
                Debug.Log("Not enough coins! Collect more to finish the game.");
            }
        }
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
