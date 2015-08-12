using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class adScript : MonoBehaviour {
    bool adsReady = false;
    bool showingAd = false;
    public GameObject gameOver;

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
                Advertisement.Show(null, new ShowOptions
                {
                    resultCallback = result =>
                    {
                        Debug.Log(result.ToString());
                        if (result == ShowResult.Finished)
                        {
                            Application.LoadLevel(0);
                        }
                    }

                }
                );
                adsReady = true;
                showingAd = false;
            }
        }
    }

    
	void Start () {
	
	}

}
