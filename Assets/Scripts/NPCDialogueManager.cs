using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip loopingCall;

    public bool playLoopAtStart = true;

    public AudioClip[] lines;

    public GameObject marker;

    public ObjectiveManager objectiveManager;
    public int objectiveIndexToChange = 1;
    public string newObjectiveText;

    private int currentIndex = -1;
    private bool loopStopped = false;

    void Start()
    {
        if (playLoopAtStart && loopingCall != null)
        {
            audioSource.clip = loopingCall;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void Interact()
    {
        if (!loopStopped)
        {
            audioSource.Stop();
            audioSource.loop = false;
            loopStopped = true;
        }

        currentIndex++;

        // Out of lines
        if (currentIndex >= lines.Length)
        {
            if (marker != null) marker.SetActive(false);
            return;
        }

        // Play next line
        audioSource.clip = lines[currentIndex];
        audioSource.Play();

        // If this is the objective-changing line:
        if (currentIndex == objectiveIndexToChange)
        {
            objectiveManager.SetObjective(newObjectiveText);
        }
    }
}