using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{
    public string interstitialId;
    public string rewardedId;

    InterstitialAd interstitial;
    RewardedAd rewardAd;

    int rewardAmount;
    public static AdsManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
    }

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        RequestRewardedAd();
    }

    #region Interstital Ads 
    void RequestInterstitial()
    {
        interstitial = new InterstitialAd(interstitialId);

        //call events
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdOpening += HandleOnAdOpened;
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request); //load & show the banner ad
    }

    //show the ad
    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }


    //events below
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        //do this when ad fails to load
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //do this when ad is opened
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
        interstitial.Destroy();
        RequestInterstitial();
        Debug.Log("Interstital Ad Showed");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //do this when on leaving application;
    }

    #endregion

    #region Rewarded Ads
    void RequestRewardedAd()
    {
        rewardAd = new RewardedAd(rewardedId);

        //call events
        rewardAd.OnAdLoaded += HandleRewardAdLoaded;
        rewardAd.OnAdFailedToLoad += HandleRewardAdFailedToLoad;
        rewardAd.OnAdOpening += HandleRewardAdOpening;
        rewardAd.OnAdFailedToShow += HandleRewardAdFailedToShow;
        rewardAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardAd.OnAdClosed += HandleRewardAdClosed;


        AdRequest request = new AdRequest.Builder().Build();
        rewardAd.LoadAd(request); //load & show the banner ad
    }

    //attach to a button that plays ad if ready
    public void ShowRewardedAd(int reward)
    {
        if (rewardAd.IsLoaded())
        {
            rewardAmount = reward;
            rewardAd.Show();
        }
    }

    //call events
    public void HandleRewardAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleRewardAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        //do this when ad fails to loads
        Debug.Log("Ad failed to load" + args.Message);
    }

    public void HandleRewardAdOpening(object sender, EventArgs args)
    {
        //do this when ad is opening
    }

    public void HandleRewardAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        //do this when ad fails to show
    }

    public void HandleUserEarnedReward(object sender, EventArgs args)
    {
        //reward the player here
        ShopManager.instance.UpdateCoin(rewardAmount, true);
    }

    public void HandleRewardAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
        RequestRewardedAd();
    }
    #endregion
}
