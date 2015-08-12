using UnityEngine;
using System.Collections;

public class asteroidGeneratorScript : MonoBehaviour {

    public GameObject[] asteroids;
    int maxAsteroids = 2;
    public static int asteroidAmount = 2;
    Transform m_transform;
    public static bool spawning = true;

    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(spawnAsteroids());
        StartCoroutine(increaseDifficulty());
	}

    IEnumerator increaseDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            maxAsteroids++;
        }
    }

    IEnumerator spawnAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (asteroidAmount < maxAsteroids && spawning)
            {
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], m_transform.position + new Vector3(Random.Range(-70f, 70f), 0f, 0f), Quaternion.identity);
                asteroidAmount++;
            }
        }
    }

}
