using UnityEngine;

public class DuckGameManager : MonoBehaviour
{
    public static DuckGameManager Instance;

    public GameObject[] ducks;
    public float resetDelay = 2f;

    private int hitCount = 0;
    private bool resetting = false;
    private float timer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (resetting)
        {
            timer += Time.deltaTime;
            if (timer >= resetDelay)
            {
                ResetGame();
            }
        }
    }

    public void RegisterHit()
    {
        hitCount++;

        if (hitCount >= 5)
        {
            resetting = true;
            timer = 0f;
        }
    }

    void ResetGame()
    {
        foreach (GameObject duck in ducks)
        {
            duck.SetActive(true);
        }

        hitCount = 0;
        resetting = false;
        timer = 0f;
    }
}