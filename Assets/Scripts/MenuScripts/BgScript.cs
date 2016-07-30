using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BgScript : MonoBehaviour
{

    public Color startColor;
    public Color endColor;
    public Color currentColor;
    public float duration;




    Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        SetColor();
        image.color = currentColor;
    }


    void SetColor()
    {
        currentColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1f));
        currentColor.a = 1f;

    }

}

