using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class CollectMoney : MonoBehaviour
{
    public GameObject money;
    public void Interact()
    {
        money.SetActive(false);
    }
    
}
