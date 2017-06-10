using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    private bool isFreeze = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void freezeScreen()
    {
        if (isFreeze)
        {
            Time.timeScale = 0;
            isFreeze = !isFreeze;
        }
        else
        {
            Time.timeScale = 1;
            isFreeze = !isFreeze;
        }
    }
}
