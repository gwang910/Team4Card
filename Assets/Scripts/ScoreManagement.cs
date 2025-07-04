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
        SetBestScore();//Start에서 최고 점수 갱신 함수가 호출된다.
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

        if (PlayerPrefs.HasKey(key)) //키 값이 있는지 확인하는 if문, key에 저장된 정보가 있다면
        {
            currentBestScore = PlayerPrefs.GetFloat(key); //key의 점수를 현재 최고 점수로 할당하고
        }
        else
        {
            currentBestScore = time; //없다면 현재 점수를 최고 점수에 할당한다!
            isNewRecord = true; //최고 점수를 갱신 했을 때를 확인하는 boolean값.
        }

        if (time < currentBestScore) //현재 점수와 비교해 최고 점수를 정한다!
        {
            currentBestScore = time;
            isNewRecord = true;
        }

        if (isNewRecord) //최고 기록을 갱신했다면, key에 새로운 값을 저장한다.
        {
            PlayerPrefs.SetFloat(key, currentBestScore);
        }

        ShowNewBest(isNewRecord);//isNewRecord 값에 따라 함수의 작동을 변경한다.

        if (bestScore != null)
        {
            bestScore.text = currentBestScore.ToString("N2"); //bestScore에 해당 함수에서 정해진 최고 점수를 출력한다.
        }
    }

    private string GetBestScoreKey()
    {
        switch (stageNumber)//각 스테이지의 최고 점수 정보를 담는 키를 선택한다.
        {
            case 1: return BEST_SCORE_KEY1;
            case 2: return BEST_SCORE_KEY2;
            case 3: return BEST_SCORE_KEY3;
            default: return BEST_SCORE_KEY1;
        }
    }

    private void ShowNewBest(bool isNew)
    {
        if (isNew && newBest != null)//isNewRecord의 boolean에 따라
        {
            newBest.gameObject.SetActive(true);//newBest를 활성화 할지
        }
        else if(!isNew && newBest != null)
        {
            newBest.gameObject.SetActive(false);//비활성화 할지 선택한다.
        }
    }
}
