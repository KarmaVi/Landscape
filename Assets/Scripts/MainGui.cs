using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGui : MonoBehaviour
{
    [SerializeField] private GUISkin _skin;
    
    private Rect windowRect = new Rect (Screen.width * 0.4f, Screen.height * 0.4f, 330, 300);

    public void OnGUI()
    {
        windowRect = GUI.Window(0, windowRect, WindowFunction, "Pause"); 
    }
    public void WindowFunction(int windowID)
    {
        if (GUI.Button(new Rect(windowRect.width * 0.2f, 30, 220, 50), "Continue"))
            print("Continue");
        if (GUI.Button(new Rect(windowRect.width * 0.2f, 90, 220, 50), "Restart"))
            print("Restart");
        if (GUI.Button(new Rect(windowRect.width * 0.2f, 150, 220, 50), "Settings"))
            print("Settings");
        if (GUI.Button(new Rect(windowRect.width * 0.2f, 210, 220, 50), "Exit"))
            print("Exit");
    }
}
