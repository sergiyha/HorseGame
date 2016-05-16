using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    // Use this for initialization
    public float speed;
    float position;
    public Renderer renderer;
    Vector2 offset;


    void Start()
    {
        renderer = GetComponent<Renderer>();

      
    }
	void Update () {
       
        position += speed*Time.deltaTime;
        if (position > 1.0f) position -= 1.0f;
      //  Debug.Log(position);


        renderer.material.mainTextureOffset = new Vector2(position,0f);
	
	}
}
