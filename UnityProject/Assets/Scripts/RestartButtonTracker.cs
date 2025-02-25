using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class RestartButtonTracker : MonoBehaviour
{
    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (restartButton!= null)
        {
            restartButton.onClick.AddListener(OnRestartButtonPressed);
        }
        
    }

    void OnRestartButtonPressed()
    {
        //Track button press
        Analytics.CustomEvent("restart_button_pressed", new System.Collections.Generic.Dictionary<string, object>
        {
            { "button_pressed", true },
            { "timestamp", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
        });

        Debug.Log("Restart Button Pressed");
    }
}
