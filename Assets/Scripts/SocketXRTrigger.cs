using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketXRTrigger : MonoBehaviour
{
    public int socketIndex;
    public RandomSocketManager manager;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Socket " + socketIndex + " triggered");
        manager.CheckSocket(socketIndex);
    }
}