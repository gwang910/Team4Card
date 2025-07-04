using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour
{
    public GameObject CautionPanel;

    public void ShowDeletePanel()
    {
        CautionPanel.SetActive(true);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        CautionPanel.SetActive(false);
    }

    public void DoNotDelete()
    {
        CautionPanel.SetActive(false);
    }
}
