using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public void StartScene()
    {
        TKSceneManager.ChangeScene("StartScene");
    }
    public void PlayScene()
    {
        TKSceneManager.ChangeScene("PlayScene");
    }
    public void EndScene()
    {
        TKSceneManager.ChangeScene("EndScene");
    }
    public void CustomScene()
    {
        TKSceneManager.ChangeScene("CustomScene");
    }
    public void ModeSize3Easy()
    {
        TKSceneManager.ChangeScene("ModeSize3Easy");
    }
    
}
