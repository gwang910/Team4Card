using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

    public GameObject front;
    public GameObject back;
    public GameObject cardBackground;

    public Animator anim; 

    public SpriteRenderer frontImage;

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Photo{idx}");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        cardBackground.SetActive(true);
        back.SetActive(false);
    }
}
