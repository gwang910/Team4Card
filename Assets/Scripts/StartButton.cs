using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MyButtonClicked()
    {
        Debug.Log("Button clicked!");
        audioSource = GetComponent<AudioSource>();
    }
}