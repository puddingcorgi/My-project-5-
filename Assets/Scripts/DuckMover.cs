using UnityEngine;

public class DuckMover : MonoBehaviour
{
    public float moveDistance = 0.2f;
    public float moveSpeed = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}