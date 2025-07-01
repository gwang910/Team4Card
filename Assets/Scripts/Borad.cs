using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borad : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 3) * 1.75f - 1.75f;
            float y = (i / 3) * 2.0f - 3.6f;

            go.transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
