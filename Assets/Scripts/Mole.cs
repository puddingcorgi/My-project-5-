using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{
    public float popHeight = 0.35f;
    public float visibleTime = 1.5f;
    public float stunTime = 2f;

    public AudioClip hitClip;

    private Vector3 hiddenPos;
    private Vector3 visiblePos;
    private bool isUp = false;
    private bool isStunned = false;

    private Renderer rend;
    private Color originalColor;
    private Vector3 originalScale;
    private AudioSource audioSource;

    void Start()
    {
        hiddenPos = transform.position;
        visiblePos = hiddenPos + Vector3.up * popHeight;

        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        originalScale = transform.localScale;

        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator PopRoutine()
    {
        if (isStunned || isUp)
            yield break;

        isUp = true;
        transform.position = visiblePos;

        yield return new WaitForSeconds(visibleTime);

        if (!isStunned)
        {
            transform.position = hiddenPos;
            isUp = false;
        }
    }

    public void Hit()
    {
        if (!isUp || isStunned)
            return;

        StartCoroutine(StunRoutine());
    }

    IEnumerator StunRoutine()
    {
        isStunned = true;

        if (audioSource != null && hitClip != null)
        {
            audioSource.PlayOneShot(hitClip);
        }

        rend.material.color = Color.yellow;
        transform.localScale = originalScale * 1.5f;

        yield return new WaitForSeconds(stunTime);

        rend.material.color = originalColor;
        transform.localScale = originalScale;
        transform.position = hiddenPos;

        isUp = false;
        isStunned = false;
    }
}