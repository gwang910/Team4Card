using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HiddenStageBoard : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCard", 0.0f, 0.5f);
    }

    void MakeCard()
    {
        Instantiate(card);
    }
}
