using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickIconNext : MonoBehaviour {
    public GameObject suggest;      //true
    public GameObject question;     //false
    private bool flag = true;
    public void clickIcon()
    {
        if(flag==true)
        {
            suggest.SetActive(true);
            question.SetActive(false);
            flag = false;
        }
        else
        {
            suggest.SetActive(false);
            question.SetActive(true);
            flag = true;
        }
    }
}