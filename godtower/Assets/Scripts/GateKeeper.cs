using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GateKeeper : MonoBehaviour {
    
    public string levelNumber;
    public string password;
    public string nextSceneName;
    public Text levelText;
    public InputField passwordInput;
    public Text accessDeniedText;
    // Update is called once per frame
    void Update () {
        if(Time.timeSinceLevelLoad % 2 < 1)
        {
            levelText.text = "LEVEL";
        }
        else
        {
            levelText.text = levelNumber;
        }
        if(Input.GetKey(KeyCode.Return))
        {
            checkPassword();
        }
    }

    public void checkPassword()
    {
        if (string.IsNullOrEmpty(passwordInput.text.Trim()))
            return;

        if (passwordInput.text.Trim() == password)
        {
            TKSceneManager.ChangeScene(nextSceneName);
        }
        else
        {
            accessDeniedText.gameObject.SetActive(true);
        }
    }

}
