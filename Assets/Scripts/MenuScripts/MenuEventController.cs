using UnityEngine;
using System.Collections;

public class MenuEventController : MonoBehaviour {
    public GameObject [] trueText;
    public GameObject[] fakeText;
    
    void SetActiveTrurText()
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
   public  void SetActiveFakeText()
    {
        trueText[0].SetActive(false);
        trueText[1].SetActive(false);
        trueText[2].SetActive(false);
        trueText[3].SetActive(false);

        fakeText[0].SetActive(true);
        fakeText[1].SetActive(true);
        fakeText[2].SetActive(true);
        fakeText[3].SetActive(true);

    }
}
