using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void OnMouseDown()
    {
        SceneManager.LoadScene("HiddenStage");
    }
    public void LongLiveTheKing()
    {
        crownFall = true;
    }
}
