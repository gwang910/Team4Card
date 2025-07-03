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
        GameManager.Instance.SetCardCount(20);

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        arr = arr.OrderBy(X => Random.Range(0f, 5f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.12f;
            float y = -(i / 4) * 1.82f + 3.11f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
            go.GetComponent<Card>().Deal(i);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
