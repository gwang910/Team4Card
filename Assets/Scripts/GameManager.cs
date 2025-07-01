using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endTxt;
    float time = 0.0f;


    public GameObject firstcard;
    public GameObject secondcard;               // GameObject ���� Card��ũ��Ʈ����
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
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }
    }

    public void CardMatched()
    {
        if(firstcard == secondcard)
        {
            firstcard.IsDestroyed();
            secondcard.IsDestroyed();
            cardCount -= 2;

            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            // �ٽ� ������
        }

        firstcard = null;
        secondcard = null;      // ���� �ʱ�ȭ
    }
}
