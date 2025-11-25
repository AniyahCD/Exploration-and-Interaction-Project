using UnityEngine;

public class FloatMarker : MonoBehaviour
{
    public float floatHeight = 0.25f;   // how high it floats
    public float floatSpeed = 2f;       // how fast it floats
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}