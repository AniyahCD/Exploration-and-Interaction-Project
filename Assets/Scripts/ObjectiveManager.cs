using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    public void SetObjective(string newText)
    {
        objectiveText.text = newText;
    }
}
