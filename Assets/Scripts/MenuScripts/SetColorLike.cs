using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetColorLike : MonoBehaviour {
 
    private Image thisImage;
    private BgScript bgScript;

	// Use this for initialization
	void Start () {
        bgScript = FindObjectOfType<BgScript>();      
        thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        thisImage.color = bgScript.currentColor;
	}
}
