using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour {

	public void CaptureScreen()
    {
        Application.CaptureScreenshot("ScreenShotImage.png", 4);
    }
		
}
