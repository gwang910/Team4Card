using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public Animator[] textAnimators;
    public float delayBetween = 1.0f;
    public GameObject text0;
    public GameObject text1;
    public GameObject text2;
    public GameObject teamName;
    public GameObject StartButton;
    public GameObject DeleteAllButton;
    public AudioSource effectSource;
    public AudioClip effectSound1;
    public AudioClip effectSound2;

    void Start()
    {
        StartCoroutine(PlaySequence());
        Time.timeScale = 1.0f;
    }

    IEnumerator PlaySequence()
    {
        text0.SetActive(true);
        textAnimators[0].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);
        effectSource.PlayOneShot(effectSound1);

        text1.SetActive(true);
        textAnimators[1].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);
        effectSource.PlayOneShot(effectSound1);

        text2.SetActive(true);
        textAnimators[2].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);
        effectSource.PlayOneShot(effectSound1);

        teamName.SetActive(true);
        textAnimators[3].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);
        effectSource.PlayOneShot(effectSound2);

        StartButton.SetActive(true);
        textAnimators[4].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);
        effectSource.PlayOneShot(effectSound2);

        DeleteAllButton.SetActive(true);
    }
}
