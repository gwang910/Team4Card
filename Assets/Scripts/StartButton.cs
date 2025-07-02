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
        AudioManager.Instance.effectSource.PlayOneShot(startSound); // ����� �Ŵ������� ���� : ��ư�� ����ġ ���Ҹ� �ϵ���

        SceneManager.LoadScene("StageScene"); // ��� ��ȯ

    }
    public void MyButtonClicked()
    {
        Debug.Log("Button clicked!");
    }
}