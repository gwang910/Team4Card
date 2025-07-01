using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startSound;

    public void GameStart()
    {
        

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = this.startSound;
            audioSource.Play();

        SceneManager.LoadScene("MainScene");

    }
    public void MyButtonClicked()
    {
        Debug.Log("Button clicked!");
    }
}