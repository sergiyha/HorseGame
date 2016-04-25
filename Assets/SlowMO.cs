using UnityEngine;
using System.Collections;

public class SlowMO : MonoBehaviour {
    public float timeScale;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timeScale;
	
	}
}
