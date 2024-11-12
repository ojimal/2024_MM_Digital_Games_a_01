using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Load the main menu scene (scene index 0)
        SceneManager.LoadScene(0);
    }
}
