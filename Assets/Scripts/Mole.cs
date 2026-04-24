using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float popHeight = 0.35f;
    public float visibleTime = 1.5f;
    public float stunTime = 2f;

    private Vector3 hiddenPos;
    private Vector3 visiblePos;
    private bool isUp = false;
    private bool isStunned = false;
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        hiddenPos = transform.position;
        visiblePos = hiddenPos + Vector3.up * popHeight;

        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        //UnityEngine.Debug.Log(gameObject.name + " Start finished");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mallet"))
        {
            Hit();
        }
    }

    public IEnumerator PopRoutine()
    {
        if (isStunned || isUp)
            yield break;

        isUp = true;
        //UnityEngine.Debug.Log(gameObject.name + " popped up");

        transform.position = visiblePos;

        yield return new WaitForSeconds(visibleTime);

        if (!isStunned)
        {
            transform.position = hiddenPos;
            isUp = false;
            //UnityEngine.Debug.Log(gameObject.name + " went back down");
        }
    }

    public void Hit()
    {
        //UnityEngine.Debug.Log(gameObject.name + " Hit() called, isUp=" + isUp + ", isStunned=" + isStunned);

        if (!isUp || isStunned)
            return;

        StartCoroutine(StunRoutine());
    }

    IEnumerator StunRoutine()
    {
        //UnityEngine.Debug.Log(gameObject.name + " stunned");

        isStunned = true;
        rend.material.color = Color.yellow;

        yield return new WaitForSeconds(stunTime);

        rend.material.color = originalColor;
        transform.position = hiddenPos;
        isUp = false;
        isStunned = false;

        //UnityEngine.Debug.Log(gameObject.name + " recovered");
    }
}