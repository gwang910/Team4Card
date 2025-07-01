using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTuna : MonoBehaviour
{
    public GameObject tuna;
    void Start()
    {
        InvokeRepeating("maketuna", 0.0f, 1.5f);
    }
    void maketuna()
    {
        Instantiate(tuna);
    }

}
