using UnityEngine;
using TMPro;
using System.Collections;

public class TimedDialogue : MonoBehaviour
{
    public TMP_Text timedText;   // Assign your TMP Text in the Inspector
    public float displayDuration = 5f; // Duration of text on screen

    void Start()
    {
        // Auto-assign if script is on the same object as the TMP text
        if (timedText == null)
            timedText = GetComponent<TMP_Text>();

        StartCoroutine(ShowAndHideText());
    }

    IEnumerator ShowAndHideText()
    {
        timedText.enabled = true;               // Show the text
        yield return new WaitForSeconds(displayDuration);
        timedText.enabled = false;              // Hide the text
    }
}
