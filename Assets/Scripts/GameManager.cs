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
    public GameObject secondcard;               // GameObject 추후 Card스크립트연결

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        
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
        }
        else
        {
            // 다시 뒤집기
        }

        firstcard = null;
        secondcard = null;      // 선택 초기화
    }
}
