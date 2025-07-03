using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    const string BEST_SCORE_KEY = "BestScore";

    private float time;

    public Text nowScore;
    public Text bestScore;
    public Text newBest;

    private void Start()
    {
        SetNowScore();
        SetBestScore();
    }
    private void SetNowScore()
    {
        time = GameManager.Instance.GetTime();
        if (nowScore != null)
        {
            nowScore.text = time.ToString("N2");
        }
    }
    private void SetBestScore()
    {
        float currentBestScore;
        bool isNewRecord = false;
        if (PlayerPrefs.HasKey(BEST_SCORE_KEY))
        {
            currentBestScore = PlayerPrefs.GetFloat(BEST_SCORE_KEY);
        }
        else
        {
            currentBestScore = time;
            isNewRecord = true;
        }
        if (time < currentBestScore)
        {
            currentBestScore = time;
            isNewRecord = true;
        }
        if (isNewRecord)
        {
            PlayerPrefs.SetFloat(BEST_SCORE_KEY, currentBestScore);
            if (newBest != null)
            {
                newBest.gameObject.SetActive(true);
            }
        }
        else
        {
            if (newBest != null)
            {
                newBest.gameObject.SetActive(false);
            }
        }
        if (bestScore != null)
        {
            bestScore.text = currentBestScore.ToString("N2");
        }
    }
}
