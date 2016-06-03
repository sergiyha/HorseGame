using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KnightFidingAway : MonoBehaviour
{
    public float duration;
   

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DoFade());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * duration;
            yield return null;
        }

        
    } 



   
}

