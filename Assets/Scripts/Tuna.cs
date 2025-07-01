using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : MonoBehaviour
{
    float speed = 0.007f;

    void Start()
    {
        float x = 4.5f;
        float y = Random.Range(5.0f, -5.0f);
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;
        if (transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
    }
}
