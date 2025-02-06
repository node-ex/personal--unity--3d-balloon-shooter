using UnityEngine;
using TMPro;
using System.Collections;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] CanvasGroup winPanel;
    [SerializeField] float fadeSpeed = 1f;
    [SerializeField] float showWinPanelDelayInSeconds = 3f;

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
    }

    void Start()
    {
        GameManager.BalloonPopped += UpdateScore;
        UpdateScore();
    }

    void OnDestroy()
    {
        GameManager.BalloonPopped -= UpdateScore;
    }

    void UpdateScore()
    {
        scoreText.text = $"{GameManager.Instance.PoppedBalloons} / {GameManager.Instance.BalloonsToPop}";
    }

    public IEnumerator ShowWinPanel()
    {
        while (winPanel.alpha < 1)
        {
            winPanel.alpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
