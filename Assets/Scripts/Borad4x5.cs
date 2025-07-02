using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Borad4x5 : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetCardCount(12);

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        arr = arr.OrderBy(X => Random.Range(0f, 5f)).ToArray();

        for (int i = 0; i < 12; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 3) * 1.75f - 1.75f;
            float y = (i / 3) * 2.0f - 3.6f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
            go.GetComponent<Card>().Deal (i);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
