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

    public Text timeTxt;
    public GameObject endClearTxt;
    public GameObject endFailTxt;
    public GameObject endFailPrefab;

    AudioSource audioSource;
    public AudioClip clearclip;
    public AudioClip failclip;

    public Card firstcard;
    public Card secondcard;               // Connect to GameObject Card
    public int cardCount = 0;

    private float time = 0.0f;
    private float finishedTime = 0.0f;
    bool isfail = false;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        cardCount = 12;
    }
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f && !isfail)
        {
            Time.timeScale = 0.0f;
            //Instantiate(endFailPrefab);
            endPanelFail.ShowEndPanel();
            isfail = true;
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
                Time.timeScale = 0.0f;
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("EndScene");
    }

}
