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
        bgmSource.loop = true;
    }

    public void PlayDefaultBGM()
    {
        if (bgmSource != null && BackGroundSound != null)
        {
            bgmSource.Stop();
            bgmSource.clip = BackGroundSound;
            bgmSource.Play();
            bgmSource.loop = true;
        }
    }



    void Update()
    {

        if (animator == null)
        {
            GameObject timeTxt = GameObject.Find("TimeTxt");
            if (timeTxt != null)
            {
                animator = timeTxt.GetComponent<Animator>();
            }
            else
            {
                return;
            }
        }

        if (animator != null) // ‘animator 오브젝트가 지정되었을때’의 조건문.
        {
            bool isTimeUp = animator.GetBool("TimeUp"); // 스크립트 내 isTimeUp의 bool값을 animator 오브젝트의 “TimeUp”의 bool값에서 끌어와서 지정


            if (isTimeUp && !wasTimeUp) // isTimeUp의 bool값이 wasTimeUp의 bool값과 다를 때의 조건문.
                                        // wasTimeUp은 이 코드 이전에 false로 지정함.
                                        // 즉, isTimeUp의 bool값이 true일때의 조건문이 됨.
            {
                bgmSource.Stop(); // 재생중이던 배경음악 정지
                bgmSource.clip = this.TimeUpSound; // 제한시간 임박 시의 배경음악으로 전환
                bgmSource.Play(); // 배경음악 재생
                bgmSource.loop = true; // 배경음악이 끝났을 때, 반복해서 재생되게 함.
            }

            wasTimeUp = isTimeUp; // wasTimeUp의 bool값을 true로 지정함으로써 현재 상태 저장(음악 중복재생 방지)
        }


    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // AudioManager 파괴 방지
        }
        else
        {
            Destroy(gameObject); // 배경음악 중복재생 방지
        }

    }

}
