using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip loopingCall;

    public bool playLoopAtStart = true;

    public AudioClip[] lines;

    public GameObject marker;

    public GameObject money;

    Animator animator;

    public ObjectiveManager objectiveManager;
    public int objectiveIndexToChangeUI;
    public int objectiveIndexToChangeMoney;
    public string newObjectiveText;

    private int currentIndex = -1;
    private bool loopStopped = false;

    void Start()
    {
        animator = GetComponent<Animator>();

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

        if (animator != null)
        {
            animator.Play("Standing Idle");
        }

        ++currentIndex;

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
        if (currentIndex == objectiveIndexToChangeUI)
        {
            objectiveManager.SetObjective(newObjectiveText);
        }

        if (currentIndex == objectiveIndexToChangeMoney)
        {
            money.SetActive(true);
        }
    }
}