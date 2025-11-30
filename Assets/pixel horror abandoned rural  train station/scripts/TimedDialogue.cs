using UnityEngine;
using TMPro;
using System.Collections;

public class TimedDialogue : MonoBehaviour
{
    public TMP_Text timedText;          // Assign your TMP Text in the Inspector
    public float displayDuration = 5f;  // Duration of text on screen

    private bool hasShown = false;      // Tracks if dialogue has already been shown

    void Start()
    {
        // Hide the text initially
        if (timedText == null)
            timedText = GetComponent<TMP_Text>();

        timedText.enabled = false;
    }

    void Update()
    {
        // Check for first SPACEBAR press
        if (!hasShown && Input.GetKeyDown(KeyCode.Space))
        {
            hasShown = true;
            StartCoroutine(ShowAndHideText());
        }
    }

    IEnumerator ShowAndHideText()
    {
        timedText.enabled = true;               // Show the text
        yield return new WaitForSeconds(displayDuration);
        timedText.enabled = false;              // Hide the text
    }
}
