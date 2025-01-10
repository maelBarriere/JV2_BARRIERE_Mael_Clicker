using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ScoreImageRange
{
    public int minScore;
    public int maxScore;
    public Image notificationImage;
    public float displayDuration = 1f;
    [HideInInspector] public bool imageDisplayed = false;
}

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public List<ScoreImageRange> scoreImageRanges;
    private int score = 0;

    public Button scorePlusFiveButton;
    public Button scorePlusTenButton;
    public Button scorePlusFifteenButton;
    public Button doubleSpeedButton;
    public AutoClicker autoClicker;

    private bool isScorePlusFiveUnlocked = false;
    private bool isScorePlusTenUnlocked = false;
    private bool isScorePlusFifteenUnlocked = false;

    void Start()
    {
        if (scorePlusFiveButton != null)
        {
            scorePlusFiveButton.gameObject.SetActive(false);
            scorePlusFiveButton.onClick.AddListener(AddScorePlusFive);
        }

        if (scorePlusTenButton != null)
        {
            scorePlusTenButton.gameObject.SetActive(false);
            scorePlusTenButton.onClick.AddListener(AddScorePlusTen);
        }

        if (scorePlusFifteenButton != null)
        {
            scorePlusFifteenButton.gameObject.SetActive(false);
            scorePlusFifteenButton.onClick.AddListener(AddScorePlusFifteen);
        }

        if (doubleSpeedButton != null)
        {
            doubleSpeedButton.onClick.AddListener(DoubleAutoClickSpeed);
        }

        foreach (var range in scoreImageRanges)
        {
            if (range.notificationImage != null)
            {
                range.notificationImage.gameObject.SetActive(false);
                range.imageDisplayed = false;
            }
        }
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();


        if (!isScorePlusFiveUnlocked && score >= 202)
        {
            UnlockScorePlusFive();
        }

        if (score >= 402 && !isScorePlusTenUnlocked)
        {
            UnlockScorePlusTen();
        }

        if (score >= 602 && !isScorePlusFifteenUnlocked)
        {
            UnlockScorePlusFifteen();
        }

        ShowNotificationForCurrentScore();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }

    private void UnlockScorePlusFive()
    {
        isScorePlusFiveUnlocked = true;
        if (scorePlusFiveButton != null)
        {
            scorePlusFiveButton.gameObject.SetActive(true);
        }
    }

    private void UnlockScorePlusTen()
    {
        isScorePlusTenUnlocked = true;
        if (scorePlusTenButton != null)
        {
            scorePlusTenButton.gameObject.SetActive(true);
        }
    }

    private void UnlockScorePlusFifteen()
    {
        isScorePlusFifteenUnlocked = true;
        if (scorePlusFifteenButton != null)
        {
            scorePlusFifteenButton.gameObject.SetActive(true);
        }
    }

    public void AddScorePlusFive()
    {
        score += 5;
        UpdateScoreUI();
        ShowNotificationForCurrentScore();
    }

    public void AddScorePlusTen()
    {
        score += 10;
        UpdateScoreUI();
        ShowNotificationForCurrentScore();
    }

    public void AddScorePlusFifteen()
    {
        score += 15;
        UpdateScoreUI();
        ShowNotificationForCurrentScore();
    }

    private void ShowNotificationForCurrentScore()
    {
        foreach (var range in scoreImageRanges)
        {
            if (range.notificationImage != null)
            {
                if (score >= range.minScore && score <= range.maxScore && !range.imageDisplayed)
                {
                    range.notificationImage.gameObject.SetActive(true);
                    Invoke("HideNotificationImage", range.displayDuration);

                    range.imageDisplayed = true;
                }
            }
        }
    }

    void HideNotificationImage()
    {
        foreach (var range in scoreImageRanges)
        {
            if (range.notificationImage != null)
            {
                range.notificationImage.gameObject.SetActive(false);
            }
        }
    }

    public void DoubleAutoClickSpeed()
    {
        if (autoClicker != null)
        {
            autoClicker.ToggleDoubleSpeed();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
