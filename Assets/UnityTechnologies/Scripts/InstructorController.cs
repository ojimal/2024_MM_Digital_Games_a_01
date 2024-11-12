using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionsPanel;  // Reference to the instructions panel

    // Open the instructions panel
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    // Close the instructions panel
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
