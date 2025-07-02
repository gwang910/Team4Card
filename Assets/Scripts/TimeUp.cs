using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUp : MonoBehaviour
{

    public AudioSource bgmSource;
    public AudioClip TimeUpSound;
    public Animator animator;

    private bool wasTimeUp = false;

    void Update()
    {

        bool isTimeUp = animator.GetBool("TimeUp");

        if (isTimeUp && !wasTimeUp)
        {
            bgmSource.Stop();
            bgmSource.clip = this.TimeUpSound; // �ð��ӹ� ���� ���
            bgmSource.Play();
        }

        wasTimeUp = isTimeUp;

    }

    
}
