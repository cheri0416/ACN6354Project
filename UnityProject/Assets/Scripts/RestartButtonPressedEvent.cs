using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;


namespace Unity.Services.Analytics
{
	public class OnRestartButtonPressed : Event
    {
        public OnRestartButtonPressed() : base("restart_button_pressed")
        {
        }
    }

    public static class RestartButtonPressedEvent
    {
        public static void OnRestartButtonPressed()
        {
            AnalyticsService.Instance.RecordEvent("restart_button_pressed");
            Debug.Log("restart_button_pressed");
        }
    }

}
