using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject player;
    public Dialogue dialogue;  // Reference to the Dialogue component
    private bool dialogueTriggered = false; // Flag to prevent repeated triggering

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !dialogueTriggered) // Check if the player entered and not yet triggered
        {
            dialogueTriggered = true;      // Set the flag to true
            dialogue.StartDialogue();      // Start the dialogue
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)    // Check if the player exited the trigger zone
        {
            dialogue.EndDialogue();        // End the dialogue when exiting
            dialogueTriggered = false;     // Reset the flag for future re-entry
        }
    }
}
