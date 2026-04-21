using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Duck"))
        {
            collision.gameObject.SetActive(false);

            if (DuckGameManager.Instance != null)
            {
                DuckGameManager.Instance.RegisterHit();
            }
        }

        Destroy(gameObject);
    }
}