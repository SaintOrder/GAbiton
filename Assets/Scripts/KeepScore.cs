using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    public static int Score = DieSpace.lives;


    void Update()
    {
        Score = DieSpace.lives;
        if( Score == -1)
        {

        }
    }
      void OnGUI()
    {
        GUI.Box(new Rect(100, 50, 50, 20), Score.ToString());
    }
}
