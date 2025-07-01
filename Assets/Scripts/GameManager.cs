using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endClearTxt;
    public GameObject endFailTxt;
    float time = 0.0f;

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstcard;
    public Card secondcard;               // GameObject 추후 Card스크립트연결
    public int cardCount = 0;

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
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            Time.timeScale = 0.0f;
            endFailTxt.SetActive(true);
        }
    }

    public void CardMatched()
    {
        if(firstcard.idx == secondcard.idx)
        {
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                endClearTxt.SetActive(true);
                Time.timeScale = 0.0f;
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
}
