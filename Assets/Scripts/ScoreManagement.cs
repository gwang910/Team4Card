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
        Debug.Log(stageNumber);
        float currentBestScore;
        bool isNewRecord = false;
        string key;
        switch (stageNumber)
        {
            case 1: key = BEST_SCORE_KEY1; break;
            case 2: key = BEST_SCORE_KEY2; break;
            case 3: key = BEST_SCORE_KEY3; break;
            default: key = BEST_SCORE_KEY1; break;
        }
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
