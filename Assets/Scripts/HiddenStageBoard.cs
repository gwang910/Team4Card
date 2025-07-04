using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HiddenStageBoard : MonoBehaviour
{
    public GameObject card;
    public GameObject crown;

    bool isStopped;

    void Start()
    {
        isStopped = false;
        InvokeRepeating("MakeCard", 0.0f, 0.5f);
    }

    private void Update()
    {
        if (!isStopped)
        {
            CheckHiddenStageComplete();
        }
    }

    void MakeCard()
    {
        Instantiate(card);
    }

    void MakeCrown()
    {
        Instantiate(crown);
    }

    private void CheckHiddenStageComplete()
    {
        if (HiddenStageGM.Instance != null && !HiddenStageGM.Instance.GetIsPlay())
        {
            CancelInvoke("MakeCard");
            InvokeRepeating("MakeCrown", 0.0f, 0.1f);
            isStopped = true;
        }
    }
}