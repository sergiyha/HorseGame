using UnityEngine;
using System.Collections;

public class MenuEventController : MonoBehaviour {
    public GameObject [] trueText;
    public GameObject[] fakeText;
    
    void SetActive()
    {
        trueText[0].SetActive(true);
        trueText[1].SetActive(true);
        trueText[2].SetActive(true);
        trueText[3].SetActive(true);

        fakeText[0].SetActive(false);
        fakeText[1].SetActive(false);
        fakeText[2].SetActive(false);
        fakeText[3].SetActive(false);
    }
}
