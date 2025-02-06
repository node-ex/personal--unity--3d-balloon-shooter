using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Action BalloonPopped;
    public int BalloonsToPop = 0;
    public int PoppedBalloons = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BalloonPopped += OnBalloonPopped;
    }

    void Start()
    {
        BalloonsToPop = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }

    void OnDestroy()
    {
        BalloonPopped -= OnBalloonPopped;
    }

    public void OnBalloonPopped()
    {
        PoppedBalloons += 1;
        if (PoppedBalloons == BalloonsToPop)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You win!");
        StartCoroutine(UiManager.Instance.ShowWinPanel());
    }
}
