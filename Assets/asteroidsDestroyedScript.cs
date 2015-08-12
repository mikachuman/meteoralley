using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class asteroidsDestroyedScript : MonoBehaviour {

    int asteroidsDestroyed = 0;
    public Text scoreText;
    public static asteroidsDestroyedScript current;
	// Use this for initialization
	void Start () {
        current = this;
	}

    public void addScore()
    {
        asteroidsDestroyed++;
        scoreText.text = asteroidsDestroyed.ToString();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
