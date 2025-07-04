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
        SetBestScore();//Start���� �ְ� ���� ���� �Լ��� ȣ��ȴ�.
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

        if (PlayerPrefs.HasKey(key)) //Ű ���� �ִ��� Ȯ���ϴ� if��, key�� ����� ������ �ִٸ�
        {
            currentBestScore = PlayerPrefs.GetFloat(key); //key�� ������ ���� �ְ� ������ �Ҵ��ϰ�
        }
        else
        {
            currentBestScore = time; //���ٸ� ���� ������ �ְ� ������ �Ҵ��Ѵ�!
            isNewRecord = true; //�ְ� ������ ���� ���� ���� Ȯ���ϴ� boolean��.
        }

        if (time < currentBestScore) //���� ������ ���� �ְ� ������ ���Ѵ�!
        {
            currentBestScore = time;
            isNewRecord = true;
        }

        if (isNewRecord) //�ְ� ����� �����ߴٸ�, key�� ���ο� ���� �����Ѵ�.
        {
            PlayerPrefs.SetFloat(key, currentBestScore);
        }

        ShowNewBest(isNewRecord);//isNewRecord ���� ���� �Լ��� �۵��� �����Ѵ�.

        if (bestScore != null)
        {
            bestScore.text = currentBestScore.ToString("N2"); //bestScore�� �ش� �Լ����� ������ �ְ� ������ ����Ѵ�.
        }
    }

    private string GetBestScoreKey()
    {
        switch (stageNumber)//�� ���������� �ְ� ���� ������ ��� Ű�� �����Ѵ�.
        {
            case 1: return BEST_SCORE_KEY1;
            case 2: return BEST_SCORE_KEY2;
            case 3: return BEST_SCORE_KEY3;
            default: return BEST_SCORE_KEY1;
        }
    }

    private void ShowNewBest(bool isNew)
    {
        if (isNew && newBest != null)//isNewRecord�� boolean�� ����
        {
            newBest.gameObject.SetActive(true);//newBest�� Ȱ��ȭ ����
        }
        else if(!isNew && newBest != null)
        {
            newBest.gameObject.SetActive(false);//��Ȱ��ȭ ���� �����Ѵ�.
        }
    }
}
