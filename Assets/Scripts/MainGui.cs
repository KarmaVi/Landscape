using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGui : MonoBehaviour
{
    [SerializeField] private GUISkin _skin;
    [SerializeField] private Renderer _goRenderer;

    private bool _isVisible = true;

    private float _sliderValue = 0;
    private float _redColorValue = 0;
    private float _greenColorValue = 0;
    private float _blueColorValue = 0;
    private float _transparenColortValue = 0;
    private Rect windowRect = new Rect (Screen.width * 0.33f, Screen.height * 0.3f, 330, 300);

    public void OnGUI()
    {

        if (GUI.Button(new Rect(0, 0, 100, 30), "Menu"))
        {
            _isVisible = !_isVisible;
        }
        if (!_isVisible)
        {
            return;
        }
        windowRect = GUI.Window(0, windowRect, WindowFunction, "Pause", _skin.window);

        GUILayout.BeginArea(new Rect(20, 50, 250, 150));

        _redColorValue = ColorSlider(_redColorValue, "Red");
        _greenColorValue = ColorSlider(_greenColorValue, "Green");
        _blueColorValue = ColorSlider(_blueColorValue, "Blue");
        _transparenColortValue = ColorSlider(_transparenColortValue, "Transparent");

        GUILayout.EndArea();
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

    private float ColorSlider(float currentValue, string ColorName)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(ColorName);
        currentValue = GUILayout.HorizontalSlider(currentValue, 0, 255);
        GUILayout.EndHorizontal();

        return currentValue;
    }

    public void Update()
    {
        if (_goRenderer != null)
        {
            _goRenderer.material.color = new Color(_redColorValue / 255f, _blueColorValue / 255f, _greenColorValue / 255f, _transparenColortValue / 255f);
        }
    }
}
