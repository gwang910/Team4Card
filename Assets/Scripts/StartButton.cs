using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void GameStart()
    {
        AudioManager.Instance.effectSource.PlayOneShot(startSound); // 오디오 매니저에서 실행 : 버튼은 스위치 역할만 하도록

        SceneManager.LoadScene("StageScene"); // 장면 전환

    }
    public void MyButtonClicked()
    {
        Debug.Log("Button clicked!");
    }
}