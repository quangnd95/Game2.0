using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BananaController : MonoBehaviour {
    public static int count;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
        count++;
    }
}
