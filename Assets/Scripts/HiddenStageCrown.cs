using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenStageCrown : MonoBehaviour
{
    private const float X_MIN_POSITION = -3.0f;
    private const float X_MAX_POSITION = 3.0f;
    private const float Y_POSITION = 6.0f;
    private const float Y_MIN_POSITION = -7.0f;
    // Start is called before the first frame update
    void Start()
    {
        SetTransform();
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < Y_MIN_POSITION)
        {
            Destroy(gameObject);
        }
    }
    void SetTransform()
    {
        float x = Random.Range(X_MIN_POSITION, X_MAX_POSITION);
        float y = Y_POSITION;
        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
}
