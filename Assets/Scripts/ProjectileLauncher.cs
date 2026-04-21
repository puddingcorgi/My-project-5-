using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 10f;
    public float reloadTime = 1f;

    private float lastShotTime = -999f;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ∞¥ø’∏Ò∑¢…‰
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }
    }

    public void TryShoot()
    {
        if (Time.time - lastShotTime < reloadTime)
            return;

        lastShotTime = Time.time;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * shootForce;
        }
    }
}