using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLyVaCham : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPrefs.SetInt("diem", BananaController.count);
        BananaController.count = 0;
        TKSceneManager.ChangeScene("DIE");
        
    }

}
