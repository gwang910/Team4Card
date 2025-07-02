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

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstcard;
    public Card secondcard;               // GameObject ���� Card��ũ��Ʈ����
    public int cardCount = 0;

    private bool isPlay = true;
    private float time = 0.0f;
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
        if (isPlay == true)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            if (time > 30.0f)
            {
                isPlay = false;
                Time.timeScale = 0.0f;
                endFailTxt.SetActive(true);
            }
        }
    }

    public void CardMatched()
    {
        if(firstcard.idx == secondcard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                isPlay = false;
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
        secondcard = null;      // ���� �ʱ�ȭ
    }

    public float GetTime()
    {
        return time;
    }
}
