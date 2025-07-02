using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Borad : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        // ▼▼▼▼▼ 이 부분을 이렇게 바꿔보세요 ▼▼▼▼▼
        // 만약 GameManager의 스테이지 정보가 설정되지 않았다면 (값이 0이라면),
        // 현재 씬의 이름에 따라 테스트 값을 직접 설정합니다.
        if (GameManager.stageRows == 0)
        {
            // 현재 열려있는 씬의 이름을 가져옵니다.
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == "Stage2_4x4")
            {
                Debug.Log("테스트 모드: 4x4로 설정합니다.");
                GameManager.stageRows = 4;
                GameManager.stageCols = 4;
            }
            else // 그 외의 씬(MainScene 등)은 3x4로 테스트
            {
                Debug.Log("테스트 모드: 3x4로 설정합니다.");
                GameManager.stageRows = 4;
                GameManager.stageCols = 3;
            }
        }
        // ▲▲▲▲▲ 이제 더 이상 코드를 수정할 필요가 없어요! ▲▲▲▲▲


        int rows = GameManager.stageRows;
        int cols = GameManager.stageCols;

        float cardScale = 1.0f; // 기본 카드 크기 (1.0 = 100%)
        float xSpacing = 1.5f;  // 기본 가로 간격
        float ySpacing = 2.2f;  // 기본 세로 간격

        if (cols == 4) // 만약 가로 카드 개수가 4개라면 (즉, 4x4 스테이지라면)
        {
            cardScale = 0.7f;  // 카드 크기를 80%로 줄임
            xSpacing = 1.2f;   // 가로 간격을 줄임
            ySpacing = 2.0f;   // 세로 간격을 줄임
        }

        int totalCards = rows * cols;
        GameManager.Instance.SetCardCount(totalCards);

        List<int> cardNumbers = new List<int>();
        for (int i = 0; i < totalCards / 2; i++)
        {
            cardNumbers.Add(i);
            cardNumbers.Add(i);
        }

        var shuffledNumbers = cardNumbers.OrderBy(x => Random.value).ToList();

        for (int r = 0; r < rows; r++) // 행(row)만큼 반복
        {
            for (int c = 0; c < cols; c++) // 열(column)만큼 반복
            {
                int cardIndex = r * cols + c;

                GameObject newCard = Instantiate(card, this.transform);

                newCard.transform.localScale = new Vector3(cardScale, cardScale, 1f); // 크기 적용!

                float xPos = (c - (cols - 1) / 2.0f) * 1.5f;
                float yPos = (-r + (rows - 1) / 2.0f) * ySpacing - 0.5f; // <-- 뒤에 -y 추가!

                newCard.transform.position = new Vector2(xPos, yPos);

                newCard.GetComponent<Card>().Setting(shuffledNumbers[cardIndex]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
