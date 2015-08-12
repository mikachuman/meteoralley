using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class adScript : MonoBehaviour {
    bool adsReady = false;
    bool showingAd = false;

    void Awake() {
        if (Advertisement.isSupported) {
            Advertisement.Initialize("61738", true);
        } else {
            Debug.Log("Platform not supported");
        }
        //showAd();
    }

    // Use this function to show the ad
    public void showAd()
    {
        if (!showingAd)
        {
            showingAd = true;
            StartCoroutine(pollAds());
        }
    }

    IEnumerator pollAds()
    {
        while (!adsReady)
        {
            yield return new WaitForSeconds(1f);
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                adsReady = true;
                showingAd = false;
            }
        }
    }

    

    // ID: 61738
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
