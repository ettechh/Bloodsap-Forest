using UnityEngine;
using TMPro;

public class StoryDialogue : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] sentences;

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    public MonoBehaviour playerMovement;
    public MonoBehaviour playerLook;

    private int index = 0;

    private void Start()
    {
        // Disable player movement
        if (playerMovement) playerMovement.enabled = false;
        if (playerLook) playerLook.enabled = false;

        // Unlock cursor for UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialoguePanel.SetActive(true);
        ShowSentence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        index++;

        if (index < sentences.Length)
        {
            ShowSentence();
        }
        else
        {
            EndDialogue();
        }
    }

    void ShowSentence()
    {
        dialogueText.text = sentences[index];
    }

    void EndDialogue()
    {
        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Re-enable FPS controls
        if (playerMovement) playerMovement.enabled = true;
        if (playerLook) playerLook.enabled = true;

        // Lock cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
