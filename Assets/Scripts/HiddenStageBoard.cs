using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HiddenStageBoard : MonoBehaviour
{
    public GameObject card;
    bool isStopped;
    // Start is called before the first frame update
    void Start()
    {
        isStopped = false;
        InvokeRepeating("MakeCard", 0.0f, 0.5f);
    }

    private void Update()
    {
        if (isStopped == false)
        {
            if (HiddenStageGM.Instance.GetIsPlay() == false)
            {
                CancelInvoke("MakeCard");
                isStopped = true;
            }
        }
    }
    void MakeCard()
    {
        Instantiate(card);
    }
}