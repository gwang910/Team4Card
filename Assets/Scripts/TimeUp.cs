using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUp : MonoBehaviour
{

    public AudioSource bgmSource;
    public AudioClip TimeUpSound;
    public Animator animator;

    void Update()
    {

        bool isTimeUp = animator.GetBool("TimeUp");

        if (isTimeUp == true)
        {
            bgmSource.Stop();
            bgmSource.clip = this.TimeUpSound; // 시간임박 음악 재생
            bgmSource.Play();
        }

    }

    
}
