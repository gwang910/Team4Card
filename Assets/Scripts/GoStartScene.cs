using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStartScene : MonoBehaviour
{ 
    public void GoStart()
    {      
        SceneManager.LoadScene("StartScene"); // ��� ��ȯ
    }
}
