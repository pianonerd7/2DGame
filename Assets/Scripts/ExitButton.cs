﻿using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    public void OnMouseDown()
    {
        Debug.Log("you pressed exit");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
