using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public static ButtonClickSound Instance;
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
