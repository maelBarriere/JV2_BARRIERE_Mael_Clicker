using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<AutoHideAndRespawn> autoHideObjects; 
    public GameObject endGameImage; 
    public GameObject highScoreEndGameImage;
    public ScoreManager scoreManager; 

    private bool gameEnded = false; 

    void Start()
    {
        if (endGameImage != null)
        {
            endGameImage.SetActive(false);
        }

        if (highScoreEndGameImage != null)
        {
            highScoreEndGameImage.SetActive(false);
        }
    }

    void Update()
    {
        CheckEndGameCondition();
    }

    private void CheckEndGameCondition()
    {
        if (gameEnded) return;

        if (scoreManager != null && scoreManager.GetScore() > 999)
        {
            ShowHighScoreEndGame();
            return;
        }

        foreach (var obj in autoHideObjects)
        {
            if (!obj.IsHidden())
            {
                return; 
            }
        }

        ShowNormalEndGame();
    }

    private void ShowNormalEndGame()
    {
        gameEnded = true;

        if (endGameImage != null)
        {
            endGameImage.SetActive(true); 
        }

        Debug.Log("Fin du jeu (tous les objets cachés) !");
    }

    private void ShowHighScoreEndGame()
    {
        gameEnded = true; 

        if (highScoreEndGameImage != null)
        {
            highScoreEndGameImage.SetActive(true); 
        }

        Debug.Log("Fin du jeu (score supérieur à 999) !");
    }
}

