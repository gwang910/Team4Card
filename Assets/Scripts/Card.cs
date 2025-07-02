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

    Vector3 targetPosition;

    void Start()
    {
        // get position from Board.cs
        targetPosition = transform.position;

        // start with origin position
        transform.position = new Vector3(0, 0, 0);
    }

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

    // card dealing; used in board.cs
    public void Deal(int index)
    {
        StartCoroutine(MoveToPosition(index * 0.2f));
    }

    IEnumerator MoveToPosition(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
            yield return null;
        }

        transform.position = targetPosition;

        GameManager.Instance.NotifyCardArrived();
    }


}
