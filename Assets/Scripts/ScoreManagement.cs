using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    const string BEST_SCORE_KEY1 = "BestScore1";
    const string BEST_SCORE_KEY2 = "BestScore2";
    const string BEST_SCORE_KEY3 = "BestScore3";

    private float time;

    public Text nowScore;
    public Text bestScore;
    public Text newBest;

    private int stageNumber;

    private void Start()
    {
        Init();
        SetNowScore();
        SetBestScore();
    }

    private void Init()
    {
        stageNumber = GameManager.Instance.GetStageNumber();
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

        string key = GetBestScoreKey();

        bool isNewRecord = false;

        if (PlayerPrefs.HasKey(key))
        {
            currentBestScore = PlayerPrefs.GetFloat(key);
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
            PlayerPrefs.SetFloat(key, currentBestScore);
        }

        ShowNewBest(isNewRecord);

        if (bestScore != null)
        {
            bestScore.text = currentBestScore.ToString("N2");
        }
    }

    private string GetBestScoreKey()
    {
        switch (stageNumber)
        {
            case 1: return BEST_SCORE_KEY1;
            case 2: return BEST_SCORE_KEY2;
            case 3: return BEST_SCORE_KEY3;
            default: return BEST_SCORE_KEY1;
        }
    }

    private void ShowNewBest(bool isNew)
    {
        if (isNew && newBest != null)
        {
            newBest.gameObject.SetActive(true);
        }
        else if(!isNew && newBest != null)
        {
            newBest.gameObject.SetActive(false);
        }
    }
}
