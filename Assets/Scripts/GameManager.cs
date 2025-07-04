using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EndPanelFail endPanelFail;
    public static GameManager Instance;
    public Animator timeanime;

    public Text timeTxt;
    public GameObject endClearTxt;
    public GameObject endFailTxt;
    public GameObject endFailPrefab;

    public static int stageRows;
    public static int stageCols;

    AudioSource audioSource;
    public AudioClip clearclip;
    public AudioClip failclip;


    public Card firstcard;
    public Card secondcard;               // Connect to GameObject Card
    public int cardCount = 0;
    int stageCards;

    private float time = 0.0f;
    private float finishedTime = 0.0f;
    bool stopTime;
    bool isfail = false;

    public bool isCardReady = false;   // for waiting card dealing animation
    int arrivedCardCount = 0;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        stopTime = false;
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        timeanime.SetBool("TimeUp", false);
    }
    void Update()
    {
        
        if (!stopTime && isCardReady)
        {
            timeTxt.text = time.ToString("N2");
            time += Time.deltaTime;
        }

        if (time > 19.5f)
        {
            timeanime.SetTrigger("TimeUp");
            timeanime.SetBool("TimeUp", true);
        }

        if (time > 30.0f && !isfail)
        {
            AudioManager.Instance.PlayDefaultBGM();
            Time.timeScale = 0.0f;
            //Instantiate(endFailPrefab);
            endPanelFail.ShowEndPanel();
            isfail = true;
        }
    }
    public void CardMatched()
    {
        if (firstcard.idx == secondcard.idx)
        {
            audioSource.PlayOneShot(clearclip);
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                stopTime = true;

                if (time > 19.5f)
                {
                    AudioManager.Instance.PlayDefaultBGM();
                }

                finishedTime = time;
                StartCoroutine(DelayLoadClearScene());
            }
        }
        else
        {
            firstcard.CloseCard();
            secondcard.CloseCard();
            Invoke("CloseFailCard", 0.6f);      // closefailcard sound delay
        }

        firstcard = null;
        secondcard = null;      // use at card.cs
    }
    public void SetCardCount(int count)
    {
        stageCards = count;
        cardCount = count;
    }
    public float GetTime()
    {
        return finishedTime;
    }
    void CloseFailCard()
    {
        audioSource.PlayOneShot(failclip);
    }
    // coroutine of loading ClearScene
    IEnumerator DelayLoadClearScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        string currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Stage1_4x3")
        {
            PlayerPrefs.SetInt("Stage2_4x4_unlock", 1);     // 1 = true = unlock
        }
        else if(currentScene == "Stage2_4x4")
        {
            PlayerPrefs.SetInt("Stage3_4x5_unlock", 1);
        }
        PlayerPrefs.Save();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("EndScene");
    }
    public void NotifyCardArrived()
    {
        arrivedCardCount++;

        // when all cards arrive, time start
        if (arrivedCardCount >= cardCount)
        {
            isCardReady = true;     // 'true' is essential for time start
        }
    }

    public int GetStageNumber()
    {
        switch (stageCards)
        {
            case 12: 
                return 1;
            case 16: 
                return 2; 
            case 20: 
                return 3; 
            default: 
                return 1;
        }
    }
}
