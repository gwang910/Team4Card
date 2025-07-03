using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HiddenStageGM : MonoBehaviour
{
    private const float TIME_LIMIT = 60.0f;
    private const string HIDDEN_BEST_SCORE_KEY = "HiddenScore";
    private const int EASTER_EGG_PROBABILITY = 100;
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
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Init();
        GetComponents();
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 0)
        {
            SetTexts();
        }
        else
        {
            isPlay = false;
            SetHiddenScore();
        }
    }
    void Init()
    {
        time = TIME_LIMIT;
        isPlay = true;
    }
    void GetComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // coroutine of loading ClearScene
    void SetTexts()
    {
        if (timeTxt != null)
        {
            timeTxt.text = time.ToString("N0");
        }
        if (scoreTxt != null)
        {
            scoreTxt.text = score.ToString();
        }
    }
    //HiddenStageMechanisms
    public void HiddenCardMatched()
    {
        if (HFirstcard.index == HSecondcard.index)
        {
            if (Random.Range(0, EASTER_EGG_PROBABILITY) == 0)
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
        HSecondcard = null;      // use at card.cs
    }
    private void SetHiddenScore()
    {
        if (PlayerPrefs.HasKey(HIDDEN_BEST_SCORE_KEY))
        {
            int best = PlayerPrefs.GetInt(HIDDEN_BEST_SCORE_KEY);
            if (best < score)
            {
                PlayerPrefs.SetInt(HIDDEN_BEST_SCORE_KEY, score);
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
            PlayerPrefs.SetInt(HIDDEN_BEST_SCORE_KEY, score);
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
