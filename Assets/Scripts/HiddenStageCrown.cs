using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenStageCrown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = 6.0f;
        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }
    }
}
