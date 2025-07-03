using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelFail : MonoBehaviour
{
    // 이 함수가 호출되면, 자기 자신(패널)을 활성화 시킨
    // GameManager가 이 함수를 호출할 겁니다.
    public void ShowEndPanel()
    {
        gameObject.SetActive(true);
    }

    // 재시도 버튼을 위한 함수
    // 이 함수는 유니티 에디터에서 Retry 버튼의 OnClick() 이벤트에 직접 연결해줘야 합니다.
    public void OnRetryButtonClicked()
    {
        //멈췄던 시간을 다시 흐르게 하는 코드
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.Instance.PlayDefaultBGM();
    }
}