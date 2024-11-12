using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Public method to trigger the transition and load the main game scene
    public void LoadMainGame()
    {
        StartCoroutine(LoadLevel(1)); // Load scene index 1 (Main Game)
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play transition animation
        transition.SetTrigger("Start");

        // Wait for the transition duration
        yield return new WaitForSeconds(transitionTime);

        // Load the specified scene
        SceneManager.LoadScene(levelIndex);
    }
}
