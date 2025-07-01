using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelFail : MonoBehaviour
{
    private GameObject endPanelInstance;
    private bool shouldShow = false;

    public void ShowEndPanel()
    {
        shouldShow = true;
    }

    private void Update()
    {
        if (shouldShow && endPanelInstance == null)
        {
            // 프리팹 로드
            GameObject panelPrefab = Resources.Load<GameObject>("Prefabs/EndPanelFail");
            if (panelPrefab == null)
            {
                Debug.LogError("EndPanelFail 프리팹을 Resources에서 찾을 수 없습니다!");
                shouldShow = false;
                return;
            }

            // 캔버스 찾기
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("씬에 Canvas가 없습니다!");
                shouldShow = false;
                return;
            }

            // 인스턴스화
            endPanelInstance = Instantiate(panelPrefab, canvas.transform);

            // 버튼 이벤트 연결
            Button retryButton = endPanelInstance.GetComponentInChildren<Button>();
            if (retryButton != null)
            {
                retryButton.onClick.AddListener(OnRetryButtonClicked);
            }

            // 반드시 켜기
            endPanelInstance.SetActive(true);

            // 필요 시 shouldShow false로
            // shouldShow = false; // 만약 한 번만 뜨게 할 거면 주석 해제
        }
        else if (shouldShow && endPanelInstance != null)
        {
            // 이미 생성되었으면 켜기만 함
            endPanelInstance.SetActive(true);
        }
    }

    private void OnRetryButtonClicked()
    {
        Time.timeScale = 1f; // 재시작 전 시간 복구
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
