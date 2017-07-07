using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Again : MonoBehaviour {
    public Text Diem;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("diem"));
        Diem.text = "SCORE : " + PlayerPrefs.GetInt("diem");
    }
    public void again()
    {
        TKSceneManager.ChangeScene("StartScene");
    }
}
