using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;   // Reference to the TextMeshPro text component
    public string[] lines = new string[]    // Dialogue lines populated here
    {
        "Ahh! You scared me... Don't you know how to knock?",
        "Well, don't just stand there waiting for a miracle, you have to find your way out of here.",
        "Don't forget the lemons scattered around the house... and, uh... one more thing.",
        "The gargoyles and ghosts aren't exactly friendly to strangers.",
        "Keep your distance, or they might catch you!"
    };
    public float textSpeed = 0.05f;         // Speed for typing effect
    public GameObject dialogueBox;          // Reference to the dialogue box UI

    private int index;                      // Keeps track of the current line of dialogue
    private Animator animator;              // Reference to the Animator component
    private bool isDialogueActive = false;  // Keeps track of the dialogue state

    void Start()
    {
        textComponent.text = string.Empty;
        animator = dialogueBox.GetComponent<Animator>();

        // Check if the Animator component is attached
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the dialogueBox GameObject.");
        }

        dialogueBox.SetActive(false); // Keep dialogue box initially inactive
    }

    public void StartDialogue()
    {
        if (isDialogueActive) return;          // Prevent re-triggering if already active
        isDialogueActive = true;               // Set dialogue state to active
        index = 0;
        dialogueBox.SetActive(true);           // Show the dialogue box GameObject

        // Trigger expansion animation if animator is available
        if (animator != null)
        {
            animator.SetTrigger("IsExpanding");    // Trigger the IsExpanding animation
        }

        StartCoroutine(ShowFirstLineAfterExpand());
    }

    private IEnumerator ShowFirstLineAfterExpand()
    {
        yield return new WaitForSeconds(0.5f); // Wait for expand animation duration
        StartCoroutine(TypeLine());            // Start typing the first line
    }

    public void EndDialogue()
    {
        if (!isDialogueActive) return;         // Prevent re-triggering if already inactive
        StopAllCoroutines();                   // Stop any ongoing typing coroutine

        // Trigger collapse animation if animator is available
        if (animator != null)
        {
            animator.SetTrigger("IsCollapsing");   // Trigger the IsCollapsing animation
        }

        StartCoroutine(DisableDialogueBoxAfterCollapse());
    }

    private IEnumerator DisableDialogueBoxAfterCollapse()
    {
        yield return new WaitForSeconds(0.5f); // Wait for collapse animation duration
        dialogueBox.SetActive(false);          // Hide the dialogue box after collapsing
        textComponent.text = string.Empty;     // Clear the text
        isDialogueActive = false;              // Reset dialogue state
    }

    void Update()
    {
        if (isDialogueActive && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }
}
