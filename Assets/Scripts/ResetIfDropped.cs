using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ResetIfDropped : MonoBehaviour
{
    public float minY = 1.0f;
    public float maxDistance = 3.0f;

    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;
    private XRGrabInteractable grab;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();

    }

    void Update()
    {
        if (grab != null && grab.isSelected)
            return;

        if (transform.position.y < minY)
        {
            ResetObject();
        }

        if (Vector3.Distance(transform.position, startPos) > maxDistance)
        {
            ResetObject();
        }
    }

    void ResetObject()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.SetPositionAndRotation(startPos, startRot);
    }
}