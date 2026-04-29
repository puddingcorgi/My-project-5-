using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Mole mole = other.GetComponent<Mole>();

        if (mole == null)
            mole = other.GetComponentInParent<Mole>();

        if (mole != null)
        {
            mole.Hit();
        }
    }
}