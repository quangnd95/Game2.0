using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorClickController : MonoBehaviour {

    private int redIndex = 0;
    private int yellowIndex = 0;
    private int greenIndex = 0;
    private int blueIndex = 0;
    private int purpleIndex = 0;

    private string currentText; 
    private int timesClick;

    private float time = 5f;
    private int score = 0;

    public Text scoreText;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    PurpleColorBtnOnclick();
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    BlueColorBtnOnclick();
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    RedColorBtnOnclick();
        //}
        //if (Input.GetKey(KeyCode.R))
        //{
        //    YellowColorBtnOnclick();
        //}
        //if (Input.GetKey(KeyCode.T))
        //{
        //    GreenColorBtnOnclick();
        //}

        if(time > 0)
        {
            time -= Time.deltaTime;
            //Debug.Log("Time = " + time);
            
            if(time < 0)
            {
                if (CheckCode())
                {
                    //Debug.Log("You Win");
                    score++;
                    //Debug.Log("Score "+score);
                    scoreText.text = "" + score;
                    time = 5f;
                    
                    resetTimesClick();
                    
                }
                else
                {
                    //Debug.Log("You Lose");
                    //Debug.Log("TimesClick = " + timesClick);
                    SceneManager.LoadScene("EndingScene");
                    PlayerPrefs.SetInt("SCORE", score);
                }
            }
            
        }
        
    }

    public void RedColorBtnOnclick()
    {
        redIndex++;
        Debug.Log("Red click: " +redIndex);
    }

    public void YellowColorBtnOnclick()
    {
        yellowIndex++;
        Debug.Log("Yellow click: " + yellowIndex);
    }

    public void GreenColorBtnOnclick()
    {
        greenIndex++;
        Debug.Log("Green click: " + greenIndex);
    }

    public void PurpleColorBtnOnclick()
    {
        purpleIndex++;
        Debug.Log("Purple click: " + purpleIndex);
    }

    public void BlueColorBtnOnclick()
    {
        blueIndex++;
        Debug.Log("Blue click: " + blueIndex);
    }

    private bool CheckCode()
    {
        bool isWin = false;
        currentText = QuestionController.currentText;
        timesClick = QuestionController.timesClick;
        int totalTimesClick = redIndex + yellowIndex + blueIndex + greenIndex + purpleIndex;
        Debug.Log("TimesClick = " + timesClick);
        Debug.Log("total times click: " + totalTimesClick);
        switch (currentText)
        {
            case "RED":
                if (purpleIndex + yellowIndex + greenIndex + blueIndex >0)
                {
                    return false;
                }
                if (redIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "YELLOW":
                if (purpleIndex + redIndex + greenIndex + blueIndex > 0)
                {
                    return false;
                }
                if (yellowIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "BLUE":
                if (purpleIndex + yellowIndex + greenIndex + redIndex > 0)
                {
                    return false;
                }
                if (blueIndex == timesClick)
                {
                    isWin = true;

                }
                else
                {
                    isWin = false;
                }
                break;
            case "GREEN":
                if (purpleIndex + yellowIndex + redIndex + blueIndex > 0)
                {
                    return false;
                }
                if (greenIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "PURPLE":
                if (redIndex + yellowIndex + greenIndex + blueIndex > 0)
                {
                    return false;
                }
                if (purpleIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "NOT RED":
                if (redIndex > 0)
                {
                    return false;
                }
                if (purpleIndex + yellowIndex + greenIndex + blueIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "NOT YELLOW":
                if (yellowIndex > 0)
                {
                    return false;
                }
                if (purpleIndex + redIndex + greenIndex + blueIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;

                }
                break;
            case "NOT BLUE":
                if (blueIndex > 0)
                {
                    return false;
                }
                if (purpleIndex + yellowIndex + greenIndex + redIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "NOT GREEN":
                if (greenIndex > 0)
                {
                    return false;
                }
                if (purpleIndex + yellowIndex + redIndex + blueIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
            case "NOT PURPLE":
                if (purpleIndex > 0)
                {
                    return false;
                }
                if (redIndex + yellowIndex + greenIndex + blueIndex == timesClick)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
                break;
        }
        return isWin;
    }

    private void resetTimesClick()
    {
        redIndex = 0;
        yellowIndex = 0;
        blueIndex = 0;
        greenIndex = 0;
        purpleIndex = 0;
    }
}
