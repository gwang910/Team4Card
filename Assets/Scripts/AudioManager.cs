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

        if (animator != null) // ��animator ������Ʈ�� �����Ǿ��������� ���ǹ�.
        {
            bool isTimeUp = animator.GetBool("TimeUp"); // ��ũ��Ʈ �� isTimeUp�� bool���� animator ������Ʈ�� ��TimeUp���� bool������ ����ͼ� ����


            if (isTimeUp && !wasTimeUp) // isTimeUp�� bool���� wasTimeUp�� bool���� �ٸ� ���� ���ǹ�.
                                        // wasTimeUp�� �� �ڵ� ������ false�� ������.
                                        // ��, isTimeUp�� bool���� true�϶��� ���ǹ��� ��.
            {
                bgmSource.Stop(); // ������̴� ������� ����
                bgmSource.clip = this.TimeUpSound; // ���ѽð� �ӹ� ���� ����������� ��ȯ
                bgmSource.Play(); // ������� ���
                bgmSource.loop = true; // ��������� ������ ��, �ݺ��ؼ� ����ǰ� ��.
            }

            wasTimeUp = isTimeUp; // wasTimeUp�� bool���� true�� ���������ν� ���� ���� ����(���� �ߺ���� ����)
        }


    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // AudioManager �ı� ����
        }
        else
        {
            Destroy(gameObject); // ������� �ߺ���� ����
        }

    }

}
