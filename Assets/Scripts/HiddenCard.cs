using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCard : MonoBehaviour
{
    public int index;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject cardBackground;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        Setting();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 0.003f;
        if (transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        OpenCard();
    }
    public void OpenCard()
    {
        Debug.Log("Clicked");
        if (HiddenStageGM.Instance.HFirstcard == null)
        {
            audioSource.PlayOneShot(clip);
            HiddenStageGM.Instance.HFirstcard = this;
        }

        else
        {
            if(HiddenStageGM.Instance.HFirstcard != this)
            {
                HiddenStageGM.Instance.HSecondcard = this;
                HiddenStageGM.Instance.HiddenCardMatched();
            }
        }
    }

    void Setting()
    {
        float x = 4.5f;
        float y = Random.Range(5.0f, -5.0f);
        transform.position = new Vector2(x, y);
        index = Random.Range(0, 6);
        frontImage.sprite = Resources.Load<Sprite>($"Photo{index}");
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
}
