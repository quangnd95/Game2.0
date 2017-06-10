﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour {

    public static string currentText;
    public Text worldColor;
    public Text quanityColor;
    public static int timesClick;

    public Color yellowColor;
    public Color blueColor;
    public Color redColor;
    public Color greenColor;
    public Color purpleColor;

    public Image timeScale;

    private float time;

    private float timeScales;

    // Use this for initialization
    void Start () {
        timeScales = 0;
        time = 5f;
        randomWorldText();
        randomQuanityText();
        randomColor();
    }   

    // Update is called once per frame
    void Update () {
        if(time > 0)
        {
            time -= Time.deltaTime;
            
            if (ColorClickController.score <= 5)
            {
                timeScales = time / 5;

            }
            else if (ColorClickController.score > 5 && ColorClickController.score <= 10)
            {
                timeScales = time / 4.5f;
            }
            else if (ColorClickController.score > 10 && ColorClickController.score <= 15)
            {
                timeScales = time / 4;
            }
            else if (ColorClickController.score > 15 && ColorClickController.score <= 20)
            {
                timeScales = time / 3.5f;
            }
            else if (ColorClickController.score > 20 && ColorClickController.score <= 25)
            {
                timeScales = time / 3;
            }
            else if (ColorClickController.score > 25 && ColorClickController.score <= 30)
            {
                timeScales = time / 2.5f;
            }
            else if (ColorClickController.score > 3)
            {
                timeScales = time / 5;
            }
            timeScale.transform.localScale = new Vector3(timeScales, 1, 1);
            if (time < 0)
            {
                randomWorldText();
                randomQuanityText();
                randomColor();
                if(ColorClickController.score <= 5)
                {
                    time = 5f;

                } else if(ColorClickController.score > 5 && ColorClickController.score <= 10)
                {
                    time = 4.5f;
                }
                else if (ColorClickController.score > 10 && ColorClickController.score <= 15)
                {
                    time = 4f;
                }
                else if (ColorClickController.score > 15 && ColorClickController.score <= 20)
                {
                    time = 3.5f;
                }
                else if (ColorClickController.score > 20 && ColorClickController.score <= 25)
                {
                    time = 3f;
                }
                else if (ColorClickController.score > 25 && ColorClickController.score <= 30)
                {
                    time = 2.5f;
                }
                else if(ColorClickController.score > 30)
                {
                    time = 2f;
                }
            }
            
        }
    }

    // Random color for text.
    public void randomColor()
    {
        int index = UnityEngine.Random.Range(0, 5);
        switch (index)
        {
            case 0:
                worldColor.color = redColor;
                quanityColor.color = redColor;
                break;
            case 1:
                worldColor.color = yellowColor;
                quanityColor.color = yellowColor;
                break;
            case 2:
                worldColor.color = greenColor;
                quanityColor.color = greenColor;
                break;
            case 3:
                worldColor.color = purpleColor;
                quanityColor.color = purpleColor;
                break;
            case 4:
                worldColor.color = blueColor;
                quanityColor.color = blueColor;
                break;
        }
    }

    // Random Wolrd Text.
    public void randomWorldText()
    {
        int index = UnityEngine.Random.Range(0, 10);
        switch (index)
        {
            case 0:
                currentText = "RED";
                worldColor.text = "RED";
                break;
            case 1:
                currentText = "YELLOW";
                worldColor.text = "YELLOW";
                break;
            case 2:
                currentText = "GREEN";
                worldColor.text = "GREEN";
                break;
            case 3:
                currentText = "PURPLE";
                worldColor.text = "PURPLE";
                break;
            case 4:
                currentText = "BLUE";
                worldColor.text = "BLUE";
                break;
            case 5:
                currentText = "NOT RED";
                worldColor.text = "NOT RED";
                break;
            case 6:
                currentText = "NOT YELLOW";
                worldColor.text = "NOT YELLOW";
                break;
            case 7:
                currentText = "NOT GREEN";
                worldColor.text = "NOT GREEN";
                break;
            case 8:
                currentText = "NOT PURPLE";
                worldColor.text = "NOT PURPLE";
                break;
            case 9:
                currentText = "NOT BLUE";
                worldColor.text = "NOT BLUE";
                break;
        }
    }

    public void randomQuanityText()
    {
        int index = UnityEngine.Random.Range(0, 6);
        switch (index)
        {
            case 0:
                timesClick = 0;
                quanityColor.text = "X " + timesClick;
                break;
            case 1:
                timesClick = 1;
                quanityColor.text = "X " + timesClick;
                break;
            case 2:
                timesClick = 2;
                quanityColor.text = "X " + timesClick;
                break;
            case 3:
                timesClick = 3;
                quanityColor.text = "X " + timesClick;
                break;
            case 4:
                timesClick = 4;
                quanityColor.text = "X " + timesClick;
                break;
            case 5:
                timesClick = 5;
                quanityColor.text = "X " + timesClick;
                break;
        }
    }
}