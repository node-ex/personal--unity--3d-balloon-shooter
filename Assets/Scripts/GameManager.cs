using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        BalloonsToPop = GameObject.FindGameObjectsWithTag("Balloon").Length;

        BalloonPopped += OnBalloonPopped;
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
