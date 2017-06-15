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

    private float time;
    public static int score = 0;

    public Text scoreText;

    public AudioClip ButtonClick;
    public Button RedButton;
    public Button YellowButton;
    public Button GreenButton;
    public Button PurpleButton;
    public Button LightBlueButton;

    
    // Use this for initialization
    void Start() {
        score = 0;
        time = 4.5f;
    }

    // Update is called once per frame
    void Update() {
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

        if (time > 0)
        {
            time -= Time.deltaTime;
            //Debug.Log("Time = " + time);

            if (time < 0)
            {
                if (CheckCode())
                {
                    randomButton();
                    //Debug.Log("You Win");
                    score++;
                    //Debug.Log("Score "+score);
                    scoreText.text = "" + score;
                    if (score <= 5)
                    {
                        time = 4.5f;

                    } else if (score > 5 && score <= 10)
                    {
                        time = 4f;
                    }
                    else if (score > 10 && score <= 15)
                    {
                        time = 3.5f;
                    }
                    else if (score > 15 && score <= 20)
                    {
                        time = 3f;
                    }
                    else if (score > 20 && score <= 25)
                    {
                        time = 2.5f;
                    }
                    else
                    {
                        time = 2f;
                    }
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
        Debug.Log("Red click: " + redIndex);
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
                if (purpleIndex + yellowIndex + greenIndex + blueIndex > 0)
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

    public void clicked()
    {
        if ((RedButton == true) || (YellowButton == true) || (GreenButton == true) || (PurpleButton == true) || (LightBlueButton == true))
        { AudioSource.PlayClipAtPoint(ButtonClick, Vector3.zero); }
    }

    private void randomButton()
    {
        List<Vector3> vt3 = new List<Vector3>();
        vt3.Add(new Vector3(-100f, 101f, 0));
        vt3.Add(new Vector3(100f, 101f, 0));
        vt3.Add(new Vector3(-200f, -99f, 0));
        vt3.Add(new Vector3(0f, -99f, 0));
        vt3.Add(new Vector3(200f, -99f, 0));
        int randomVtRed = 0;
        int randomVtYellow;
        int randomVtGreen;
        int randomVtLightBlue;
        int randomVtPurple;
        Debug.Log(randomVtRed);

        randomVtRed = Random.Range(0, 5);
        do
        {
            randomVtYellow = Random.Range(0, 5);
            Debug.Log(randomVtYellow);
        } while (randomVtRed == randomVtYellow);
        do
        {
            randomVtGreen = Random.Range(0, 5);
        } while (randomVtGreen == randomVtYellow || randomVtGreen == randomVtRed);

        do
        {
            randomVtLightBlue = Random.Range(0, 5);
        } while (randomVtLightBlue == randomVtYellow || randomVtLightBlue == randomVtRed || randomVtLightBlue == randomVtGreen);

        do
        {
            randomVtPurple = Random.Range(0, 5);
        } while (randomVtPurple == randomVtRed || randomVtPurple == randomVtYellow || randomVtPurple == randomVtGreen || randomVtPurple== randomVtLightBlue);

        Debug.Log(randomVtGreen + "   " + randomVtLightBlue + "   " + randomVtPurple + "   " + randomVtRed + "   " + randomVtYellow);
        RedButton.transform.localPosition = vt3[randomVtRed];
        YellowButton.transform.localPosition = vt3[randomVtYellow];
        GreenButton.transform.localPosition = vt3[randomVtGreen];
        PurpleButton.transform.localPosition = vt3[randomVtPurple];
        LightBlueButton.transform.localPosition = vt3[randomVtLightBlue];
        

        //case 1:
        //    RedButton.transform.localPosition = new Vector3(-100f, 101f, 0);
        //    YellowButton.transform.localPosition = new Vector3(100f, 101f, 0);
        //    GreenButton.transform.localPosition = new Vector3(-200f, -99f, 0);
        //    PurpleButton.transform.localPosition = new Vector3(0f, -99f, 0);
        //    LightBlueButton.transform.localPosition = new Vector3(200f, -99f, 0);
        //    break;
        //default:
        //    GreenButton.transform.localPosition = new Vector3(-100, 101f, 0);
        //    YellowButton.transform.localPosition = new Vector3(100f, 101f, 0);
        //    RedButton.transform.localPosition = new Vector3(-200f, -99f, 0);
        //    PurpleButton.transform.localPosition = new Vector3(0f, -99f, 0);
        //    LightBlueButton.transform.localPosition = new Vector3(200f, -99f, 0);
        //    break;


    }
}
