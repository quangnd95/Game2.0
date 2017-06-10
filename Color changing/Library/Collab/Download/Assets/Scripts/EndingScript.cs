using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingScript : MonoBehaviour {
    public Button HomeButton;
    public Button RetryButton;
    public Text endScore;

    private void Start()
    {
        Debug.Log("End Color = " + PlayerPrefs.GetInt("SCORE"));
        endScore.text = "" + PlayerPrefs.GetInt("SCORE");
    }

    public void HomeClicked()
    {
        if (HomeButton == true)
        { SceneManager.LoadScene("StartScene"); }
    }
    public void RetryClicked()
    {
        if (RetryButton == true)
        { SceneManager.LoadScene("PlaySceneLv1"); }
    }
}
