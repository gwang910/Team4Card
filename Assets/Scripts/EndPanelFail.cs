using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelFail : MonoBehaviour
{


    private GameObject endPanelInstance;

    public void ShowEndRanel()
    {
        if (endPanelInstance == null)
        {
            GameObject panelPrefab = Resources.Load<GameObject>("Prefabs/EndPanelFail");
        }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}