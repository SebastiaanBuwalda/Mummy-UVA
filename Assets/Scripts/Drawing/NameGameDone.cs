using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGameDone : MonoBehaviour
{
    public string levelToLoad = "NameGameToOddOneOutGame";

    public void NewScene()
    {
      Application.LoadLevel(levelToLoad);
    }
}