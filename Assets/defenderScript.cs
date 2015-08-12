using UnityEngine;
using System.Collections;

public class defenderScript : MonoBehaviour {

    public static int missiles = 0;
    int maxMissiles = 2;
    public GameObject missilePrefab;
    Transform m_transform;
    public GameObject gameOver;

    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
	
	}

    void OnDestroy()
    {
        gameOver.SetActive(true);
        asteroidGeneratorScript.spawning = false;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )) &&  missiles < maxMissiles)
        {
            missiles++;
            GameObject newMissile = Instantiate(missilePrefab, m_transform.position, Quaternion.identity) as GameObject;
            newMissile.GetComponent<missileScript>().targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}
