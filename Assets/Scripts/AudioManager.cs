using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource effectSource; // ȿ���� �������� ��ư�� ����
    public AudioClip BackGroundSound;
    public AudioClip startSound;



    void Start()
    {
        bgmSource = GetComponent<AudioSource>();

        bgmSource.clip = this.BackGroundSound; // ����� ���
        bgmSource.Play();
    }




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��� ��ȯ �� �̾�������
        }
        else
        {
            Destroy(gameObject); // �ߺ���� ����
        }
    }

}
