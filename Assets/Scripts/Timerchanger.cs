using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerChanger : MonoBehaviour
{
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
                bgmSource.clip = this.TimeUpSound; // �ð��ӹ� ���� ���
                bgmSource.Play();
                bgmSource.loop = true;
            }

            wasTimeUp = isTimeUp;
        }


    }

}
