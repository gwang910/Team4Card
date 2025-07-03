using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenStageGM : MonoBehaviour
{
    public static HiddenStageGM Instance;

    AudioSource audioSource;
    public AudioClip kick;
    public AudioClip snare;
    public AudioClip hHat;
    public AudioClip failclip;
    public AudioClip hiddenTrack;

    public GameObject scorePanel;

    public HiddenCard HFirstcard;
    public HiddenCard HSecondcard;

    public Text timeTxt;
    public Text scoreTxt;
    public Text bestScoreTxt;
    public Text nowScoreTxt;

    bool isPlay;

    float time;
    
    int score = 0;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        time = 10.0f;
        isPlay = true;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 0)
        {
            timeTxt.text = time.ToString("N0");
            scoreTxt.text = score.ToString();
        }
        else
        {
            isPlay = false;
            SetHiddenScore();
        }
    }

    //HiddenStageMechanisms
    public void HiddenCardMatched()
    {
        if (HFirstcard.index == HSecondcard.index)
        {
            if (Random.Range(0, 100) == 0)
            {
                audioSource.PlayOneShot(hiddenTrack);
            }
            else
            {
                switch (score % 4)
                {
                    case 0:
                        audioSource.PlayOneShot(kick);
                        break;
                    case 1:
                        audioSource.PlayOneShot(hHat);
                        break;
                    case 2:
                        audioSource.PlayOneShot(snare);
                        break;
                    case 3:
                        audioSource.PlayOneShot(hHat);
                        break;
                    default:
                        break;
                }
            }
            HFirstcard.DestroyCard();
            HSecondcard.DestroyCard();
            score++;
        }
        else
        {
            audioSource.PlayOneShot(failclip);
        }
        HFirstcard = null;
        HSecondcard = null;
    }
    private void SetHiddenScore()
    {
        string key = "HiddenScore";

        if (PlayerPrefs.HasKey(key))
        {
            int best = PlayerPrefs.GetInt(key);
            if (best < score)
            {
                PlayerPrefs.SetInt(key, score);
                bestScoreTxt.text = score.ToString();
            }
            else
            {
                if (bestScoreTxt != null)
                {
                    bestScoreTxt.text = best.ToString();
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, score);
            bestScoreTxt.text = score.ToString();
        }
        nowScoreTxt.text = score.ToString();
        scoreTxt.gameObject.SetActive(false);
        scorePanel.gameObject.SetActive(true);
    }
    public bool GetIsPlay()
    {
        return isPlay;
    }
}
