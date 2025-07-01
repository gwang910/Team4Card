using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MyButtonClicked()
    {
        Debug.Log("Button clicked!");
    }
}