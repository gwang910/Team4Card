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

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        text0.SetActive(true);
        textAnimators[0].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);

        text1.SetActive(true);
        textAnimators[1].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);

        text2.SetActive(true);
        textAnimators[2].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);

        teamName.SetActive(true);
        textAnimators[3].SetTrigger("Enter");
        yield return new WaitForSeconds(delayBetween);

        StartButton.SetActive(true);
        textAnimators[4].SetTrigger("Enter");
    }
}
