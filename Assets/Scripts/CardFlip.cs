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

    public Animator animFront;
    public Animator animBack;

    public SpriteRenderer frontSprite;
    public SpriteRenderer backSprite;

    public Text nameTxt;

    public Crown crown;

    float yTrack;

    int count;

    bool btnBool;

    private void Start()
    {
        btnBool = false;
        yTrack = 360.0f;
        count = 0;
        animFront = frontCard.GetComponent<Animator>();
        animBack = backCard.GetComponent<Animator>();
        frontSprite = frontCard.GetComponent<SpriteRenderer>();
        backSprite = backCard.GetComponent<SpriteRenderer>();
        frontSprite.enabled = false;
        backSprite.enabled = true;
        nameTxt.enabled = false;
    }
    public void Update()
    {
        if (backCard.transform.rotation.eulerAngles.y < 90 || backCard.transform.rotation.eulerAngles.y > 270)
        {
            frontSprite.enabled = false;
        }
        else
        {
            frontSprite.enabled = true;
        }
        if (backCard.transform.rotation.eulerAngles.y > yTrack)
        {
            count++;
        }
        yTrack = backCard.transform.rotation.eulerAngles.y;
        if (count == 3 && backCard.transform.rotation.eulerAngles.y <= 180)
        {
            animFront.enabled = false;
            animBack.enabled = false;
            backCard.transform.rotation = Quaternion.Euler(0, 180.0f, 0); //����ϰ� 180���� �α� ����
            nameTxt.enabled = true;
            count++; //if��� �� ���ϵ��� �ϱ� ����
        }
    }

    public void FlipCard()
    {
        if (btnBool == false) //�� ���� �۵��ϵ���
        {
            animFront.enabled = true;
            animBack.enabled = true;
            btnBool = true;
            crown.LongLiveTheKing();
        }
    }
}
