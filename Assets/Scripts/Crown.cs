using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crown : MonoBehaviour
{
    const float CROWN_Y_POSITION = 1.65f;
    const float CROWN_SPEED = 0.001f;

    bool crownFall = false;
    void Update()
    {
        if (crownFall)
        {
            CrownMovement();
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
    private void CrownMovement()
    {
        if (transform.position.y > CROWN_Y_POSITION)
        {
            transform.position += Vector3.down * CROWN_SPEED;
        }
    }
}
