using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;         //Scene넘어갈때 필요한 코드

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endClearTxt;
    public GameObject endFailTxt;
    public GameObject endFailPrefab;

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstcard;
    public Card secondcard;               // GameObject 추후 Card스크립트연결
    public int cardCount = 0;

    private bool isPlay = true;
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
        if (isfail == false)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            if (time > 30.0f)
            {
                isPlay = false;
                Time.timeScale = 0.0f;
                endFailTxt.SetActive(true);
            }
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            if (time > 30.0f && !isfail)
            {
                Time.timeScale = 0.0f;
                Instantiate(endFailPrefab);
                isfail = true;
            }
        }
    }

    public void CardMatched()
    {
        if (firstcard.idx == secondcard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                isPlay = false;
                Time.timeScale = 0.0f;
                finishedTime = time;
                LoadClearScene();
            }
        }
        else
        {
            firstcard.CloseCard();
            secondcard.CloseCard();
        }

        firstcard = null;
        secondcard = null;      // 선택 초기화
    }

    public float GetTime()
    {
        return finishedTime;
    }
    public void LoadClearScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("EndScene");
    }
}
