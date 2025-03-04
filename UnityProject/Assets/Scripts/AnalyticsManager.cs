using UnityEngine;
using Unity.Services.Core;
using System;
using UnityEngine.UI;
using Unity.Services.Analytics;


namespace Unity.Service.Analytics
{
	public class AnalyticsManager : MonoBehaviour
    {
       
        async void Start()
        {
            await UnityServices.InitializeAsync();
            Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        }

        public void GiveConsent()
        {
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log($"Consent provided. SDK now collecting data!");
        }
    
        public void OnRestartButtonPressed()
        {
            RestartButtonPressedEvent.OnRestartButtonPressed();
           
            
        }
    }
}
    

    
    



