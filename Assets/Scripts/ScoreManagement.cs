using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    private float time;

    public Text nowScore;
    public Text bestScore;

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
        string key = "BestScore";

        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best > time)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                if(bestScore != null)
                {
                    bestScore.text = best.ToString("N2");
                }
                
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }
    }
}
