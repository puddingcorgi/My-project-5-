using UnityEngine;
using System.Collections;

public class WhacAMoleManager : MonoBehaviour
{
    public Mole[] moles;
    public float minDelay = 1f;
    public float maxDelay = 2.5f;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minDelay, maxDelay));

            int index = UnityEngine.Random.Range(0, moles.Length);
            StartCoroutine(moles[index].PopRoutine());
        }
    }
}