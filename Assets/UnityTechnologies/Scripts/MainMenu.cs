using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader; // Reference to the LevelLoader component

    private void Start()
    {
        // Ensure levelLoader is assigned
        if (levelLoader == null)
        {
            levelLoader = FindObjectOfType<LevelLoader>();
        }
    }

    public void PlayGame()
    {
        // Call the LoadMainGame method in LevelLoader to start the transition
        levelLoader.LoadMainGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
