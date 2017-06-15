using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Again : MonoBehaviour {
    public Text Diem;
    private void Start()
    {
        Diem.text = "SCORE : " + PlayerPrefs.GetInt("diem");
    }
    public void again()
    {
        TKSceneManager.ChangeScene("StartScene");
    }
}
