using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HienDiem : MonoBehaviour {
    private Text diem;
    // Use this for initialization
    private void Update()
    {
        diem = gameObject.GetComponent<Text>();
        diem.text = "" + BananaController.count;
    }
}
