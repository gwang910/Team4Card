using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    bool crownFall = false;

    void Update()
    {
        if(crownFall == true && transform.position.y > 1.65f)
        {
            transform.position += Vector3.down * 0.001f;
        }
    }
    public void LongLiveTheKing()
    {
        crownFall = true;
    }
}
