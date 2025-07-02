using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource effectSource; // 효과음 재생명령은 버튼에 있음
    public AudioClip BackGroundSound;
    public AudioClip startSound;



    void Start()
    {
        bgmSource = GetComponent<AudioSource>();

        bgmSource.clip = this.BackGroundSound; // 배경음 재생
        bgmSource.Play();
    }




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 장면 전환 후 이어지도록
        }
        else
        {
            Destroy(gameObject); // 중복재생 방지
        }
    }

}
