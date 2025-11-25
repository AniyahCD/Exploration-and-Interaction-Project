using UnityEngine;

public class ColliderOff : MonoBehaviour
{
    private Collider doorcollider;

    public void Awake()
    {
        doorcollider = GetComponent<Collider>();
    }
    public void Interact()
    {
        doorcollider.enabled = false;
    }
}
