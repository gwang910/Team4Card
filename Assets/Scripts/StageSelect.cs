using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public Button stage4x4Button;
    public Button stage4x5Button;
    public GameObject lockIcon4x4;
    public GameObject lockIcon4x5;

    private void Start()
    {
        int isCleared = PlayerPrefs.GetInt
    }
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStage4x4()
    {
        SceneManager.LoadScene("Stage2_4x4Scene");
    }
    public void LoadStage4x5()
    {
        SceneManager.LoadScene("Stage3_4x5Scene");
    }
}