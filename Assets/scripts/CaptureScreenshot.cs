using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{

    public int superSize = 3;
    private int _shotIndex = 0;

    private void Update () 
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            ScreenCapture.CaptureScreenshot($"aitrust-unityScreenShot{_shotIndex}.png", superSize);
            Debug.Log("key pressed ");
        }
    }
}
