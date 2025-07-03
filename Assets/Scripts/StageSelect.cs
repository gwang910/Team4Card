using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public Button stage2_4x4Button;
    public Button stage3_4x5Button;
    public GameObject lockIcon4x4;
    public GameObject lockIcon4x5;

    private Animator lockAnimator4x4;
    private Animator lockAnimator4x5;

    public float fadeOutAnimationDuration = 1.0f;

    private void Start()
    {
        int stage2_4x4Unlock = PlayerPrefs.GetInt("Stage2_4x4_unlock", 0);      // unlock or lock?
        int stage3_4x5Unlock = PlayerPrefs.GetInt("Stage3_4x5_unlock", 0);

        lockAnimator4x4 = lockIcon4x4.GetComponent<Animator>();
        lockAnimator4x5 = lockIcon4x5.GetComponent<Animator>();

        if (stage2_4x4Unlock == 1)
        {
            stage2_4x4Button.interactable = true;

            lockIcon4x4.SetActive(true);

            if (PlayerPrefs.GetString("NewlyUnlocked","") == "stage2_4x4")
            {
                lockIcon4x4.SetActive(true);
                if (lockAnimator4x4 != null)
                {
                    lockAnimator4x4.ResetTrigger("FadeOut");
                    lockAnimator4x4.SetTrigger("FadeOut");      //Only one animation do
                    StartCoroutine(DisableAfterAnimation(lockIcon4x4, 0.5f));
                }
            }
            else
            {
                lockIcon4x4.SetActive(false);
            }
        }
        else
        {
            stage2_4x4Button.interactable = false;
            lockIcon4x4.SetActive(true);
        }

        if (stage3_4x5Unlock == 1)
        {
            stage3_4x5Button.interactable = true;

            lockIcon4x5.SetActive(true);

            if (PlayerPrefs.GetString("NewlyUnlocked", "") == "stage3_4x5")
            {
                lockIcon4x5.SetActive(true);
                if (lockAnimator4x5 != null)
                {
                    lockAnimator4x5.ResetTrigger("FadeOut");
                    lockAnimator4x5.SetTrigger("FadeOut");      //Only one animation do
                    StartCoroutine(DisableAfterAnimation(lockIcon4x5, 0.5f));
                }
            }
            else
            {
                lockIcon4x5.SetActive(false);
            }
        }
        else
        {
            stage3_4x5Button.interactable = false;
            lockIcon4x5.SetActive(true);
        }
        PlayerPrefs.DeleteKey("NewlyUnlocked");         // if dont deletekey > stageclear > animation always
        PlayerPrefs.Save();
    }

    private IEnumerator DisableAfterAnimation(GameObject lockIcon, float delay)
    {
        yield return new WaitForSeconds(delay);
        lockIcon.SetActive(false);
    }

    public void LoadStage4x3()
    {
        SceneManager.LoadScene("Stage1_4x3");
    }

    public void LoadStage4x4()
    {
        SceneManager.LoadScene("Stage2_4x4");
    }
    public void LoadStage4x5()
    {
        SceneManager.LoadScene("Stage3_4x5");
    }
}