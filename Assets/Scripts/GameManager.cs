using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;         //Scene�Ѿ�� �ʿ��� �ڵ�

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endFailPrefab;
    float time = 0.0f;

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstcard;
    public Card secondcard;               // GameObject ���� Card��ũ��Ʈ����
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
            audioSource.PlayOneShot(clip);
            firstcard.DestroyCard();
            secondcard.DestroyCard();
            cardCount -= 2;

            if (cardCount == -12)
            {
                Time.timeScale = 0.0f;
                LoadClearScene();
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

    public void LoadClearScene()
    {
        Debug.Log("�����ߴ��ض�");
        SceneManager.LoadScene("EndScene");
    }
}
