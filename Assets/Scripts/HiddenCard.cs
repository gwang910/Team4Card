using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCard : MonoBehaviour
{
    private const float CARD_SPEED = 0.003f;
    private const float CARD_MAX_X_POSITION = -4.5f;
    private const float X_START_POSITION = 4.5f;
    private const float Y_MIN_POSITION = -5.0f;
    private const float Y_MAX_POSITION = 5.0f;

    public int index;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject cardBackground;

    AudioSource audioSource;
    public AudioClip clip;

    public Animator anim;

    void Start()
    {
        SetPosition();
        SetImage();
        GetComponents();
    }
    // Update is called once per frame
    void Update()
    {
        if (HiddenStageGM.Instance.GetIsPlay() == true)
        {
            MoveCard();
        }
        else
        {
            DestroyCard();
        }
    }
    private void OnMouseDown()
    {
        OpenCard();
    }
    public void OpenCard()
    {
        if (HiddenStageGM.Instance.HFirstcard == this)
        {
            return;
        }
        if (HiddenStageGM.Instance.HFirstcard == null)
        {
            audioSource.PlayOneShot(clip);
            HiddenStageGM.Instance.HFirstcard = this;
        }
        else
        {
            HiddenStageGM.Instance.HSecondcard = this;
            HiddenStageGM.Instance.HiddenCardMatched();
        }
    }
    private void MoveCard()
    {
        transform.position += Vector3.left * CARD_SPEED;
        if (transform.position.x < CARD_MAX_X_POSITION)
        {
            Destroy(gameObject);
        }
    }
    void SetPosition()
    {
        float x = X_START_POSITION;
        float y = Random.Range(Y_MIN_POSITION, Y_MAX_POSITION);
        transform.position = new Vector2(x, y);
    }
    void SetImage()
    {
        index = Random.Range(0, 6);
        frontImage.sprite = Resources.Load<Sprite>($"Photo{index}");
    }
    void GetComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void DestroyCard()
    {
        anim.SetBool("isMatched", true);
        Invoke("DestroyCardInvoke", 0.3f);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
}
