using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class CardFlip : MonoBehaviour
{
    public GameObject frontCard;
    public GameObject backCard;

    public AudioSource audioSource;

    public AudioClip flipSound;

    public Animator animFront;
    public Animator animBack;

    public SpriteRenderer frontSprite;
    public SpriteRenderer backSprite;

    public Text nameTxt;

    public Crown crown;

    float yTrack;

    int flipCount;

    bool hasFlipped;
    bool flipOver;
    bool isFlipComplete;

    private void Start()
    {
        Init();
        GetComponents();
    }
    public void Update()
    {
        UpdateSprites();
        FlipCounter();
        if(flipOver && !isFlipComplete){
            FlipComplete();
        }
    }
    private void Init()
    {
        flipOver = false;
        hasFlipped = false;
        isFlipComplete = false;
        yTrack = 360.0f;
        flipCount = 0;
        frontSprite.enabled = false;
        backSprite.enabled = true;
        nameTxt.enabled = false;
    }
    private void GetComponents()
    {
        audioSource = GetComponent<AudioSource>();
        animFront = frontCard.GetComponent<Animator>();
        animBack = backCard.GetComponent<Animator>();
        frontSprite = frontCard.GetComponent<SpriteRenderer>();
        backSprite = backCard.GetComponent<SpriteRenderer>();
    }
    public void FlipCard()
    {
        if (!hasFlipped) //한 번만 작동하도록
        {
            AudioManager.Instance.effectSource.PlayOneShot(flipSound);
            animFront.enabled = true;
            animBack.enabled = true;
            hasFlipped = true;
            crown.LongLiveTheKing();
        }
    }
    private void UpdateSprites()
    {
        if (backCard.transform.rotation.eulerAngles.y < 90 || backCard.transform.rotation.eulerAngles.y > 270)
        {
            frontSprite.enabled = false;
        }
        else
        {
            frontSprite.enabled = true;
        }
    }
    private void FlipCounter()
    {
        if (backCard.transform.rotation.eulerAngles.y > yTrack)
        {
            flipCount++;
            if (flipCount == 3)
            {
                flipOver = true;
            }
        }
        yTrack = backCard.transform.rotation.eulerAngles.y;
    }
    private void FlipComplete()
    {
        if (backCard.transform.rotation.eulerAngles.y <= 180)
        {
            animFront.enabled = false;
            animBack.enabled = false;
            backCard.transform.rotation = Quaternion.Euler(0, 180.0f, 0); //깔끔하게 180으로 두기 위함
            nameTxt.enabled = true;
            isFlipComplete = true;
        }
    }
}
