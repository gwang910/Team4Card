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
    public GameObject endFailPrefab;
    float time = 0.0f;

    AudioSource audioSource;
    public AudioClip clearclip;
    public AudioClip failclip;

    public Card firstcard;
    public Card secondcard;               // GameObject 추후 Card스크립트연결
    public int cardCount = 0;

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
            Instantiate(endFailPrefab);
            isfail = true;
        }
    }

    public void CardMatched()
    {
        if(firstcard.idx == secondcard.idx)
        {
            audioSource.PlayOneShot(clearclip);
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                LoadClearScene();
            }
        }
        else
        {
            audioSource.PlayOneShot(failclip);
            firstcard.CloseCard();
            secondcard.CloseCard();
        }

        firstcard = null;
        secondcard = null;      // 선택 초기화
    }

    public void LoadClearScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("EndScene");
    }
}
