using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitalizer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string AndroidGameID;
    [SerializeField] private string IOSGameID;

    public string AdPlatrom
    {
        private set { }
        get
        {
            return IsIOS() ? "_iOS" : "_Android";
        }
    }

    void Awake()
    {
        string gameID = IsIOS() ? IOSGameID : AndroidGameID;
        bool testMode = Application.platform == RuntimePlatform.WindowsEditor ? true : false;
        Debug.Log($"Unity Game ID {gameID}");
        Advertisement.Initialize(gameID, testMode, true, this);
    }

    bool IsIOS()
    {
        return Application.platform == RuntimePlatform.IPhonePlayer;
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization done.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed. {error} - {message}");
    }
}
