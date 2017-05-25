using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HideBar : MonoBehaviour {
    private Image img;
	// Use this for initialization
	void Start () {
        img = gameObject.GetComponent<Image>();
	}
    public void OnPointerEnter()
    {
        Color imageColor = img.color;
        imageColor.a = 0;
        img.color = imageColor;
    }
    public void OnPointerExit()
    {
        Color imageColor = img.color;
        imageColor.a = 1;
        img.color = imageColor;
    }
}
