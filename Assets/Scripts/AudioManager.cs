using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip BackGroundSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.BackGroundSound;
        audioSource.Play();
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
