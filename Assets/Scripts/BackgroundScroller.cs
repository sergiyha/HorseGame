using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    // Use this for initialization
    public float speed;
    float position;
    public Renderer renderer;
    Vector2 offset;
   // public static BackgroundScroller current;

    void Start()
    {
        renderer = GetComponent<Renderer>();

      
    }
	void Update () {
        /*offset = renderer.material.mainTextureOffset;
        offset.x += Time.deltaTime * speed;
        Debug.Log(offset);
        renderer.material.mainTextureOffset = offset;
        if (offset.x > 1.0f)
            offset.x -= 1.0f;*/
        position += speed*Time.deltaTime;
        if (position > 1.0f) position -= 1.0f;
      //  Debug.Log(position);


        renderer.material.mainTextureOffset = new Vector2(position,0f);
	
	}
}
