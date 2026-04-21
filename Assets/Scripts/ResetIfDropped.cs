using UnityEngine;

public class ResetIfDropped : MonoBehaviour
{
    public float minY = 0f;

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            transform.SetPositionAndRotation(startPos, startRot);
        }
    }
}