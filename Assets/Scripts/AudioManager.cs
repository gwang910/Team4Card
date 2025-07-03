using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource effectSource; 
    public AudioClip BackGroundSound;
    public AudioClip startSound;
    public AudioClip TimeUpSound;
    public Animator animator;

    private bool wasTimeUp = false;



    void Start()
    {
        bgmSource = GetComponent<AudioSource>();

        bgmSource.clip = this.BackGroundSound; 
        bgmSource.Play();
    }

    public void PlayDefaultBGM()
    {
        if (bgmSource != null && BackGroundSound != null)
        {
            bgmSource.Stop();
            bgmSource.clip = BackGroundSound;
            bgmSource.Play();
        }
    }

    void Update()
    {

        if (animator == null)
        {
            animator = GameObject.Find("TimeTxt").GetComponent<Animator>();
            if (animator == null)
            {
                return;
            }
        }

        if (animator != null)
        {
            bool isTimeUp = animator.GetBool("TimeUp");


            if (isTimeUp && !wasTimeUp)
            {
                bgmSource.Stop();
                bgmSource.clip = this.TimeUpSound; // 시간임박 음악 재생
                bgmSource.Play();
            }

            wasTimeUp = isTimeUp;
        }


    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

    }

}
