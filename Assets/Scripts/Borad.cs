using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Borad : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        int rows = 4;
        int cols = 4;
        int totalCards = 16;

        float cardScale = 0.8f;
        float xSpacing = 1.2f;
        float ySpacing = 1.8f;
        float yOffset = -1.0f; 

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetCardCount(totalCards);
        }

        List<int> cardNumbers = new List<int>();
        for (int i = 0; i < totalCards / 2; i++)
        {
            cardNumbers.Add(i);
            cardNumbers.Add(i);
        }

        var shuffledNumbers = cardNumbers.OrderBy(x => Random.value).ToList();

        for (int r = 0; r < rows; r++) 
        {
            for (int c = 0; c < cols; c++) 
            {
                int cardIndex = r * cols + c;

                GameObject newCard = Instantiate(card, this.transform);

                newCard.transform.localScale = new Vector3(cardScale, cardScale, 1f);

                float xPos = (c - (cols - 1) / 2.0f) * xSpacing;
                float yPos = (-r + (rows - 1) / 2.0f) * ySpacing + yOffset;
                newCard.transform.position = new Vector2(xPos, yPos);

                newCard.GetComponent<Card>().Setting(shuffledNumbers[cardIndex]);
            }
        }
    }
}