using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public string levelToLoad = "memoryGame";

    public void NewScene()
    {
        Application.LoadLevel(levelToLoad);
    }

}