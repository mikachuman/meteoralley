using UnityEngine;
using System.Collections;

public class destroyAfterScript : MonoBehaviour {
    float seconds = 6f;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, seconds);
	}
}
