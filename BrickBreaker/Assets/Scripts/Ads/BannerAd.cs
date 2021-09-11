using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    private string AdPlatform;
    public void Awake()
    {
        AdPlatform = GameObject.Find("Ads").GetComponent<AdsInitalizer>().AdPlatrom;
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    public void Start()
    {
        
    }

    public void OnEnable()
    {
        LoadBannerAd();
    }

    public void OnDisable()
    {
        HideBannerAd(false);
    }

    public void OnDestroy()
    {
        HideBannerAd(true);
    }

    public void HideBannerAd(bool bDestroy)
    {
        Advertisement.Banner.Hide(bDestroy);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnError
        };
        Advertisement.Banner.Load($"Banner{AdPlatform}", options);
    }

    private void OnBannerLoaded()
    {
        Advertisement.Banner.Show();
    }

    private void OnError(string strMessage)
    {
        Debug.Log($"Banner Ad load Error : {strMessage}");
    }
}
