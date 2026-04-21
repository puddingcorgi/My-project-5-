using UnityEngine;

public class RandomSocketManager : MonoBehaviour
{
    public GameObject indicator;
    public GameObject guessBall;
    public Transform[] sockets;
    public float resetDelay = 3f;

    public AudioSource audioSource;
    public AudioClip correctClip;
    public AudioClip wrongClip;

    private Vector3 ballStartPos;
    private Quaternion ballStartRot;
    private int correctSocketIndex;
    private bool roundEnded = false;
    private float timer = 0f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        ballStartPos = guessBall.transform.position;
        ballStartRot = guessBall.transform.rotation;
        StartNewRound();
    }

    void Update()
    {
        if (roundEnded)
        {
            timer += Time.deltaTime;
            if (timer >= resetDelay)
            {
                ResetRound();
            }
        }
    }

    public void CheckSocket(int socketIndex)
    {
        if (roundEnded) return;

        roundEnded = true;
        timer = 0f;

        if (socketIndex == correctSocketIndex)
        {
            indicator.GetComponent<Renderer>().material.color = Color.green;

            if (audioSource != null && correctClip != null)
            {
                audioSource.PlayOneShot(correctClip);
            }
        }
        else
        {
            indicator.GetComponent<Renderer>().material.color = Color.red;

            if (audioSource != null && wrongClip != null)
            {
                audioSource.PlayOneShot(wrongClip);
            }
        }
    }

    void StartNewRound()
    {
        correctSocketIndex = UnityEngine.Random.Range(0, sockets.Length);
        indicator.GetComponent<Renderer>().material.color = Color.white;
        roundEnded = false;
        timer = 0f;
    }

    void ResetRound()
    {
        Rigidbody rb = guessBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        guessBall.transform.SetPositionAndRotation(ballStartPos, ballStartRot);

        StartNewRound();
    }
}