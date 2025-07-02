using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;
    public GameObject cardBackground;

    public Animator anim; 

    public SpriteRenderer frontImage;

    AudioSource audioSource;
    public AudioClip clip;

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
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);

        if (GameManager.Instance.firstcard == null)
        {
            GameManager.Instance.firstcard = this;
        }

        else
        {
            GameManager.Instance.secondcard = this;
            GameManager.Instance.CardMatched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        cardBackground.SetActive(false);
        back.SetActive(true);
    }
}
