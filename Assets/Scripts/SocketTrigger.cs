using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public int socketIndex;
    public RandomSocketManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GuessObject"))
        {
            manager.CheckSocket(socketIndex);
        }
    }
}